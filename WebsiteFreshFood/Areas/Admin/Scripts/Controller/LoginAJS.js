/// <reference path="../angular.js" />
var app = angular.module("myLogin", []);

app.controller("LoginController", LoginController);
function LoginController($scope, $rootScope, $window, $http) {
    $rootScope.Users = null;
    $rootScope.US = "";
    $rootScope.PW = "";
    //$rootScope.quyenAd = "";
    //$rootScope.quyenUs = "";
   
    $rootScope.Login = function (name, pass) {
        $http({
            method: 'Post',
            params: { us: name, pw: pass },
            url: '/Admin/Login/Login'
        }).then(function (d) {
            if (d.data == "") {
                $rootScope.US = "";
                $rootScope.PW = "";
                alert("Tài khoản người dùng không đúng");
            }
            else {
                $rootScope.Users = d.data;
                $window.location.href = '/Admin/Home/Index';
                //if (da.data.Role == "admin") {
                //    $rootScope.quyenAd = "";
                //    $rootScope.quyenUs = "KhongQuyen";
                //}
                //else {
                //    $rootScope.quyenAd = "KhongQuyen";
                //    $rootScope.quyenUs = "";
                //}
            }
        }, function (e) { alert("Lỗi") });
    };


    //$rootScope.Logout = function () {
    //    $http({
    //        method: 'Post',
    //        url: '/Admin/Login/Logout'
    //    }).then(function (d) {

    //    }, function (e) { alert("Lỗi") });
    //};
}