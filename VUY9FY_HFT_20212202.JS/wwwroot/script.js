let songs = [];
let conncection = null;
getData();
let songIdToUpdate = -1;
setupSignalR();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:13442/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SongCreated", (user, message) => {
        getdata();
    });

    connection.on("SongDeleted", (user, message) => {
        getdata();
    });

    connection.on("SongUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function getData() {
    await fetch('http://localhost:13442/song')
        .then(x => x.json())
        .then(y => {
            songs = y;
            console.log(songs);
            display();
        });
}

function showupdate(id) {
    document.getElementById('updatesongNametb').value = songs.find(t => t['songId'] == id)['title']
    document.getElementById('updateformdiv').style.display = 'flex';
    songIdToUpdate = id;
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    songs.forEach(t => {
        document.getElementById('resultarea').innerHTML += 
            "<tr><td>" + t.songId + "</td><td>" +
        t.title + "</td><td>" +
        `<button type="button" onclick="remove(${t.songId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.songId})">Update</button>`
            + "</td></tr>";
    });
}

function update() {
    document.getElementById('updatesongNametb').style.display = 'none';
    let name = document.getElementById('updatesongNametb').value;
    
    fetch('http://localhost:13442/song', {
    method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { title: name, songId: songIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:13442/song/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}