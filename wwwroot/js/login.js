function demoRequest(){
    // 请求URL
    var url = "/API";
    // 请求JSON格式参数
    var parameter = { 
        APICommand: "demo",
        demo: 42 
    };
    getAPICommandData(url, parameter).then(data => {
        // 返回JSON数据
        console.log(data);
    });
}

// demoRequest();

// 1.绑定登录事件
document.querySelector("#LoginBtn").addEventListener("click", () => {
    var username = document.querySelector("input[name=UserName]").value;
    var pwd = document.querySelector("input[name=pwd]").value;

    // 2.非空校验
    if (username === "") {
        alert("用户名不能为空！");
        return false;
    }else if (pwd === "") {
        alert("密码不能为空！");
        return false;
    }

    // 3.数据校验
    var url = "/API";
    // 请求JSON格式参数
    var parameter = { 
        APICommand: "Login",
        UserName: username,
        Password:pwd 
    };
    getAPICommandData(url, parameter).then(data => {
        // 返回JSON数据
        console.log(data);
        var responseData = JSON.parse(data.Data);
        if(responseData.LoginStatus){
            setTimeout(() => {
                alert("登录成功. 1秒后跳转到Task列表页面...")
            }, 1000);
            window.location.href = "/Home?DashboardID=2";
        }else{
            alert("登录失败！");
        }
    });
});