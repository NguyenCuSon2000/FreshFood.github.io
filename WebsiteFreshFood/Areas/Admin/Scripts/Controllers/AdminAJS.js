/// <reference path="../../../../scripts/angular.js" />
var app = angular.module("LoginApp", []);
app.controller("LoginController", LoginController);
function LoginController($rootScope, $http, $window) {

    $rootScope.Users = null;
    $rootScope.UN = "";
    $rootScope.PW = "";
    $rootScope.quyenad = "";
    $rootScope.quyenus = "";

    $rootScope.Logout = function () {
        $http({
            method: 'Post',
            url: '/Admin/Login/Logout'
        }).then(function () { }, function () { });
    };

    $rootScope.Login = function (un, pw) {

        $http({
            method: 'POST',
            params: { us: un, pw: pw },
            url: '/Admin/Login/Login'
        }).then(function (d) {
            if (d.data == null) {
                $rootScope.UN = "";
                $rootScope.PW = "";
                alert("Tài khoản người dùng không đúng");
            }
            else {
                $rootScope.Users = d.data;
                //if (d.data.Role == "admin") {
                //    $rootScope.quyenad = "";
                //    $rootScope.quyenus = "KhongQuyen";
                //}
                //else {
                //    $rootScope.quyenad = "KhongQuyen";
                //    $rootScope.quyenus = "";
                //}
                $window.location.href = '/Admin/Login/Index';
            }
        }, function (e) { });
    };
};

