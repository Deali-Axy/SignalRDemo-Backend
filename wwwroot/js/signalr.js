let connection = null;
const resultDiv = document.querySelector("#result");

function setupConnection() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/count")
        .build();

    connection.on * ("someFunc", obj => {
        resultDiv.innerHTML = "Someone called this, params: " + obj.random;
    });

    connection.on("ReceiveUpdate", update => {
        resultDiv.innerHTML = update;
    });

    connection.on("Finished", () => {
        connection.stop();
        resultDiv.innerHTML = "Finished";
    });

    connection.start()
        .catch(err => console.error(err.toString()));
}

setupConnection();

document.querySelector("#submit").addEventListener("click", e => {
    e.preventDefault();

    fetch("/api/count", {
        method: "POST"
    })
        .then(response => response.text())
        .then(id => connection.invoke("GetLastestCount", id));
});