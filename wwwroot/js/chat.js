var msgCount = 0;
var username = '';
let connection = null;

function addMsg(username, datetime, content, client) {
    var elemContainer = document.createElement('div');
    elemContainer.className = "list-group-item flex-column align-items-start";
    var elemUserTime = document.createElement('div');
    elemUserTime.className = "d-flex w-100 justify-content-between";
    elemContainer.append(elemUserTime);
    var elemUser = document.createElement('h5');
    elemUser.className = "mb-1";
    elemUser.innerHTML = username;
    var elemTime = document.createElement('small');
    elemTime.innerHTML = datetime;
    elemUserTime.append(elemUser);
    elemUserTime.append(elemTime);
    var elemContent = document.createElement('p');
    elemContent.className = "mb-1";
    elemContent.innerHTML = content;
    elemContainer.append(elemContent);
    var elemClient = document.createElement('small');
    elemClient.innerHTML = client;
    elemContainer.append(elemClient);

    $('.list-group').append(elemContainer);

    // 自动滚动到底部
    window.scrollTo(0, document.querySelector('.list-group').scrollHeight);
}

function setupConnection() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

    connection.on("SendMessage", message => {
        console.log(message);
        // if (message.userName !== username)
        addMsg(`☀${message.userName}`, message.sentTimeStr, message.content, message.clientName);
    });

    connection.on("GetMessages", data => {
        console.log(data);
        for (var i = 0; i < data.length; i++) {
            let message = data[i];
            // if (message.userName !== username)
            addMsg(`☀${message.userName}`, message.sentTimeStr, message.content, message.clientName);
        }
    });

    connection.on("Finished", () => {
        connection.stop();
        console.log("finished.")
    });

    connection.start()
        .catch(err => console.error(err.toString()));
}

// 启用连接
setupConnection();

// 设置点击事件
$('#submit').on('click', function () {
    let content = $('#inputMsg').val();
    connection.invoke("SendMessage", username, content, '网页客户端');
    // addMsg(username, Date.now(), content, '网页客户端');
    $('#inputMsg').val('');
});

// 设置用户名
$('#save-username').on('click', function () {
    username = $('#username').val();
    $('#submit').attr('disabled', null);
});

// 获取设备显卡型号
// 参考：https://segmentfault.com/a/1190000010157682
var canvas = document.createElement('canvas'),
    gl = canvas.getContext('experimental-webgl'),
    debugInfo = gl.getExtension('WEBGL_debug_renderer_info');

console.log(gl.getParameter(debugInfo.UNMASKED_RENDERER_WEBGL));