/// <reference path="../../../../scripts/angular.js" />
var app = angular.module("SignApp", []);

app.controller("SignupController", SignupController);
function SignupController($scope, $rootScope, $http, $window) {

    $scope.Signup = () => {
        if ($scope.us.Pass != $scope.us.rePass) {
            alert("Mật khẩu bạn nhập không khớp nhau.");
            return;
        }

      
        // gửi thông tin ng dùng đăng kí cho controller bên mvc
        $http.post('/Admin/Signup/DangKy', $scope.us).then(res => {
            if (res.data.message) {
                alert(res.data.message);
                return;
            }
            Swal.fire({
                icon: 'success',
                title: 'Đăng ký tài khoản thành công. Bạn có muốn đăng nhập?',
                showCancelButton: true,
                confirmButtonText: 'Đăng nhập',
                cancelButtonText: 'Quay lại',
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = "/Admin/Login/Index";
                }
            });
        });
       
    }
};
