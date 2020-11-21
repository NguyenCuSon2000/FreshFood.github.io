/// <reference path="../angular.js" />
var app = angular.module("myApp", ['ngFileUpload']);

// Hiển thị sản phẩm và phân trang
app.controller("SanPhamController", function ($scope, $rootScope, $http, Upload, $timeout, $document) {

    $scope.UploadFiles = function (files) {
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/Admin/QLSanPham/Upload',
                data: { files: $scope.SelectedFiles, maloaisp: $scope.s.MaLoaiSP }
            }).then(function (d) {
                 $scope.s.HinhAnh = d.data[0];
            }, function (e) { alert("Lỗi"); });
        }
    }

    //Danh sách sản phẩm
    $http.get('/Admin/QLSanPham/GetSanPham').then(function (d) {
        $rootScope.ListSanPham = d.data;
    }, function (error) { alert('Failed'); });

    $http.get('/Admin/QLSanPham/GetLoaiSanPham').then(function (d) {
        $rootScope.listloai = d.data;
    }, function (e) { alert("Lỗi lấy loại"); });
     
    $scope.Them = function () {
        $scope._function = "Thêm sản phẩm";
        $scope.buttext = "Save";
        $scope.s = null;
    };

    $scope.Sua = function (s) {
        $scope._function = "Sửa sản phẩm";
        $scope.buttext = "Save changes";
        $scope.s = s;
    };

    $scope.Save = function () {
        //Sửa sản phẩm
        if ($scope.buttext != "Save") {
            $http({
                method: 'Post',
                datatype: 'Json',
                data: JSON.stringify($scope.s),
                url: '/Admin/QLSanPham/Update'
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.ListSanPham;
                    for (var i = 0; i < $scope.ListSanPham.length; i++)
                    { //Sửa thành công thì tiến hành sửa trên $scope
                        if ($scope.ListSanPham[i].MaSP == $scope.s.MaSP) {
                            $scope.ListSanPham[i].TenSP = $scope.s.TenSP;
                            $scope.ListSanPham[i].MaLoaiSP = $scope.s.MaLoaiSP;
                            $scope.ListSanPham[i].DonVi = $scope.s.DonVi;
                            $scope.ListSanPham[i].MoTa = $scope.s.MoTa;
                            $scope.ListSanPham[i].HinhAnh = $scope.s.HinhAnh;
                            $scope.ListSanPham[i].DonGia = $scope.s.DonGia;
                            break;
                        }
                    }
                    alert("Update success...!")
                }
            }, function (e) { alert(e); });
        }
        else //Thêm sản phẩm
        {
            $http({
                method: 'POST',
                datatype: 'json',
                url: '/Admin/QLSanPham/Insert',
                data: JSON.stringify($scope.s)
            }).then(function (d) {
                alert($scope.s.MaSP);
                if (d.data == "") {
                    $scope.ListSanPham.push($scope.s);
                    $scope.s = null;
                    alert("Data Submitted...!");
                }
                else {
                    alert(d.data);
                }
            }, function (e) {
                alert("Lỗi nhập...!");
            });
        }
    };

    $scope.XoaSanPham = function (s) {
        $http({
            method: 'Post',
            url: '/Admin/QLSanPham/Delete',
            datatype: 'Json',
            data: { id: s.MaSP }
        }).then(function (d) {
            var vt = $scope.ListSanPham.indexOf(s);
            $scope.ListSanPham.splice(vt, 1);
        }, function (e) { alert(e) });
    };

   
    //$scope.totalCount = 0;
    //$scope.maxSize = 3;
    //$scope.pageIndex = 1;
    //$scope.pageISize = 5;
    //$scope.searchName = "";

    //$scope.GetSanPhamList = function (index) {
    //    $http.get('/Admin/QLSanPham/GetSanPhamPT', {
    //        params: { pageIndex: index, pageSize: $scope.pageISize, productName = $scope.searchName }
    //    }).then(function (response) {

    //        $scope.ListSanPham = response.data.SanPhams;
    //        $scope.totalCount = response.data.totalCount;
    //        var sotrang = parseInt(response.data.totalCount) / parseInt($scope.pageISize);
    //        if (parseInt(response.data.totalCount) > sotrang * parseInt($scope.pageISize))
    //            sotrang = sotrang + 1;
    //        if (sotrang < $scope.maxSize) { $scope.maxSize = sotrang; }
    //        else { $scope.maxSize = 5; }
    //    },
    //        function (e) { alert(e); });
    //};
    //$scope.GetSanPhamList($scope.pageIndex);
});


// KHÁCH HÀNG

app.controller("KhachHangController", KhachHangController);
function KhachHangController($scope, $rootScope, $http) {
    //Danh sách khách hàng
    $http.get('/Admin/QLKhachHang/GetKhachHang').then(function (d) {
        $rootScope.ListKhachHang = d.data;
    }, function (error) { alert('Failed'); });

    $scope.Them = function () {
        $scope._function = "Thêm khách hàng";
        $scope.buttext = "Save";
        $scope.k = null;
    };

    $scope.Sua = function (k) {
        $scope._function = "Sửa khách hàng";
        $scope.buttext = "Save changes";
        $scope.k = k;
    };

    $scope.Save = function () {
        //Sửa khách hàng
        if ($scope.buttext != "Save") {
            $http({
                method: 'Post',
                datatype: 'Json',
                data: JSON.stringify($scope.k),
                url: '/Admin/QLKhachHang/Update'
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.ListKhachHang;
                    for (var i = 0; i < $scope.ListKhachHang.length; i++) {
                        //Sửa thành công thì tiến hành sửa trên $scope
                        if ($scope.ListKhachHang[i].MaKH == $scope.k.MaKH) {
                            $scope.ListKhachHang[i].TenKH = $scope.k.TenKH;
                            $scope.ListKhachHang[i].SDT = $scope.k.SDT;
                            $scope.ListKhachHang[i].DiaChi = $scope.k.DiaChi;
                            $scope.ListKhachHang[i].Email = $scope.k.Email;
                            break;
                        }
                    }
                    alert("Update success...!")
                }
            }, function (e) { alert(e); });
        }
        else //Thêm khách hàng
        {
            $http({
                method: 'POST',
                datatype: 'json',
                url: '/Admin/QLKhachHang/Insert',
                data: JSON.stringify($scope.k)
            }).then(function (d) {
                alert($scope.k.MaKH);
                if (d.data == "") {
                    $scope.ListKhachHang.push($scope.k);
                    $scope.k = null;
                    alert("Data Submitted...!");
                }
                else {
                    alert(d.data);
                }
            }, function (e) {
                alert("Lỗi nhập...!");
            });
        }
    };

    $scope.XoaKhachHang = function (k) {
        $http({
            method: 'Post',
            url: '/Admin/QLKhachHang/Delete',
            datatype: 'Json',
            data: { id: k.MaKH }
        }).then(function (d) {
            var vt = $scope.ListKhachHang.indexOf(k);
            $scope.ListKhachHang.splice(vt, 1);
        }, function (e) { alert(e) });
    };
}

// NHÀ CUNG CẤP

app.controller("NCCController", NCCController);
function NCCController($scope, $rootScope, $http, Upload, $timeout, $document) {
    //Danh sách nhà cung cấp
    $http.get('/Admin/QLNhaCungCap/GetNhaCungCap').then(function (d) {
        $rootScope.ListNhaCungCap = d.data;
    }, function (error) { alert('Failed'); });

    $scope.Them = function () {
        $scope._function = "Thêm nhà cung cấp";
        $scope.buttext = "Save";
        $scope.n = null;
    };

    $scope.Sua = function (n) {
        $scope._function = "Sửa nhà cung cấp";
        $scope.buttext = "Save changes";
        $scope.n = n;
    };

    $scope.Save = function () {
        //Sửa nhà cung cấp
        if ($scope.buttext != "Save") {
            $http({
                method: 'Post',
                datatype: 'Json',
                data: JSON.stringify($scope.n),
                url: '/Admin/QLNhaCungCap/Update'
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.ListNhaCungCap;
                    for (var i = 0; i < $scope.ListNhaCungCap.length; i++) {
                        //Sửa thành công thì tiến hành sửa trên $scope
                        if ($scope.ListNhaCungCap[i].MaKH == $scope.n.MaNCC) {
                            $scope.ListNhaCungCap[i].TenKH = $scope.n.TenNCC;
                            $scope.ListNhaCungCap[i].SDT = $scope.n.SDT;
                            $scope.ListNhaCungCap[i].DiaChi = $scope.n.DiaChi;
                            $scope.ListNhaCungCap[i].Email = $scope.n.Email;
                            $scope.ListNhaCungCap[i].Fax = $scope.n.Fax;
                            break;
                        }
                    }
                    alert("Update Success...!");
                }
            }, function (e) { alert(e); });
        }
        else //Thêm nhà cung cấp
        {
            $http({
                method: 'POST',
                datatype: 'json',
                url: '/Admin/QLNhaCungCap/Insert',
                data: JSON.stringify($scope.n)
            }).then(function (d) {
                alert($scope.n.MaNCC);
                if (d.data == "") {
                    $scope.ListNhaCungCap.push($scope.n);
                    $scope.n = null;
                    alert("Data Submitted...!");
                }
                else {
                    alert(d.data);
                }
            }, function (e) {
                alert("Lỗi nhập...!");
            });
        }
    };

    $scope.XoaNhaCungCap = function (n) {
        $http({
            method: 'Post',
            url: '/Admin/QLNhaCungCap/Delete',
            datatype: 'Json',
            data: { id: n.MaNCC }
        }).then(function (d) {
            var vt = $scope.ListNhaCungCap.indexOf(n);
            $scope.ListNhaCungCap.splice(vt, 1);
        }, function (e) { alert(e) });
    };
}
