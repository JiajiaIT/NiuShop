const APIURL = "http://localhost:2567/";
const IMGSERVER = "http://localhost:29221/";

//模态框(隐藏时)初始化
$('#myModal').on('hidden', function () {
    //标题清空
    $(".modal-header h3").text("");
    //内容清空
    $(".modal-body").html("");
    $(".modal-footer a").eq(0).text("取消");
    $(".modal-footer a").eq(1).text("保存");
    //解绑事件
    $(".modal-footer a").eq(1).unbind("click");
})


//获取地址栏参数
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
//var param=GetQueryString("参数名");
