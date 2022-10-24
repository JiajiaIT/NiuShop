
//点击登录
$(".btn-primary").click(function () {
    //获取参数
    let data = {
        Username: $("#username").val(),
        Password: $("#password").val()
    }
    //简单验证一下
    if (data.Username.trim().length == 0 || data.Password.trim().length == 0) {
        layer.msg("用户名或密码不能为空")
        return;
    }
    //提交登录
    $.post(APIURL + "api/admins/Login", data, function (res) {
        console.log(res);
        //反馈优化
        if (res.Code == 200) {
            var options = { path: '/' };
            //保存cookie
            if ($("#remember")[0].checked) {
                options.expires = 7;
            }

            //保存cookie
            $.cookie("AuthenCookie", res.Data.AdminID, options);

            //重定向到后台首页
            window.location.href = "/home/index";
        }
        else {
            layer.msg("用户名或密码不正确");
        }
    })
});