const APIURL = "http://localhost:2567/";
const IMGSERVER = "http://localhost:29221/";

var datatable_language = {
    "lengthMenu": "每页显示 _MENU_ 数",
    "zeroRecords": "抱歉，没有任何数据！",
    "info": "当前显示 _PAGE_ 共 _PAGES_ 页",
    "infoEmpty": "没有任何数据",
    "infoFiltered": "(查询 _MAX_ 条记录)",
    "sSearch": "搜索",
    "oPaginate": {
        "sFirst": "首页",
        "sPrevious": "上一页",
        "sNext": "下一页",
        "sLast": "尾页"
    }
};

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

function ViewPower(power) {
    switch (power) {

        case 1:
            return "优先"
        case 2:
            return "靠前"
        case 3:
            return "正常"
        case 4:
            return "延后"
        case 5:
            return "末尾"
    }
}