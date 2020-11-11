/// <reference path="../angular.js" />
var app = angular.module("myLogin", []);

app.controller("LoginController", LoginController);
function LoginController($scope, $rootScope, $window, $http) {
    $rootScope.US = "";
    $rootScope.PW = "";
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
            }
        }, function (e) { alert("Lỗi") });
    };
}