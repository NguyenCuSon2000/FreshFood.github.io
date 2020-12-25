/// <reference path="../../../../scripts/angular-1.3.9/angular.js" />
var app = angular.module("SanPhamApp", ['angularUtils.directives.dirPagination', 'ngFileUpload', 'ui.bootstrap']);

// Hiển thị sản phẩm và phân trang
app.controller("SanPhamController", function ($scope, $rootScope, $http, Upload) {
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
                    for (var i = 0; i < $scope.ListSanPham.length; i++) {
                        //Sửa thành công thì tiến hành sửa trên $scope
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
                //alert($scope.s.MaSP);
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

    $rootScope.TenSP = "";
    $rootScope.Search = function (tensp) {
        $rootScope.ListSanPham = null;
        $http.get('/Admin/QLSanPham/Search', {
            params: {
                TenSP: tensp
            }
        }).then(function (d) {
            if (d.data == "") {
                alert("Sản phẩm không tồn tại");
            }
            else {
                $rootScope.ListSanPham = d.data;
            }
        }, function (e) { });
    };

    $scope.maxSize = 5;     // Limit number for pagination display number.  
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero  
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->  
    $scope.pageSizeSelected = 5; // Maximum number of items per page.  

    $scope.GetSanPhamList = function () {
        $http.get("http://localhost:64769/Admin/QLSanPham/GetSanPhamPT?pageIndex=" + $scope.pageIndex + "&pageSize=" + $scope.pageSizeSelected).then(
            function (response) {
                $scope.ListSanPham = response.data.SanPhams;
                $scope.totalCount = response.data.totalCount;
            },
            function (err) {
                var error = err;
            });
    }

    //Loading employees list on first time  
    $scope.GetSanPhamList();

    //This method is calling from pagination number  
    $scope.pageChanged = function () {
        $scope.GetSanPhamList();
    };

    //This method is calling from dropDown  
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.GetSanPhamList();
    };  

    //Thống kê số lượng sản phẩm
    $scope.maloai = "";
    $http.get("http://localhost:64769/Admin/ThongKe/GetThongKe?maloai=" + $scope.maloai).then(
        function (d) {
            $rootScope.ListLoaiSP = d.data.ThongKeSLSP;
            $scope.SLSP = d.data.SLSP;
    }, function (error) { alert('Lỗi'); });

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

    $rootScope.TenKH = "";
    $rootScope.Search = function (tenkh) {
        $rootScope.ListKhachHang = null;
        $http.get('/Admin/QLKhachHang/Search', {
            params: {
                TenKH: tenkh
            }
        }).then(function (d) {
            if (d.data == "") {
                alert("Khách hàng không tồn tại");
            }
            else {
                $rootScope.ListKhachHang = d.data;
            }
        }, function (e) { });
    };
};

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

    $rootScope.TenNCC = "";
    $rootScope.Search = function (tenncc) {
        $rootScope.ListNhaCungCap = null;
        $http.get('/Admin/QLNhaCungCap/Search', {
            params: {
                TenNCC: tenncc
            }
        }).then(function (d) {
            if (d.data == "") {
                alert("Nhà cung cấp không tồn tại");
            }
            else {
                $rootScope.ListNhaCungCap = d.data;
            }
        }, function (e) { });
    };
};


// TIN TỨC
app.controller("TinTucController", TinTucController);
function TinTucController($rootScope, $scope, $http, Upload) {

    $scope.UploadFiles = function (files) {
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/Admin/QLTinTuc/Upload',
                data: { files: $scope.SelectedFiles}
            }).then(function (d) {
                $scope.t.HinhAnh = d.data[0];
            }, function (e) { alert("Lỗi"); });
        }
    };

    //Danh sách tin tức
    $http.get('/Admin/QLTinTuc/GetTinTuc').then(function (d) {
        $rootScope.ListTinTuc = d.data;
    }, function (error) { alert('Failed'); });


    $scope.Them = function () {
        $scope._function = "Thêm tin tức";
        $scope.buttext = "Save";
        $scope.t = null;
    };

    $scope.Sua = function (t) {
        $scope._function = "Sửa tin tức";
        $scope.buttext = "Save changes";
        $scope.t = t;
    };

    $scope.Save = function () {
        //Sửa tin tức
        if ($scope.buttext != "Save") {
            $http({
                method: 'Post',
                datatype: 'Json',
                data: JSON.stringify($scope.t),
                url: '/Admin/QLTinTuc/Update'
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.ListTinTuc;
                    for (var i = 0; i < $scope.ListTinTuc.length; i++) {
                        //Sửa thành công thì tiến hành sửa trên $scope
                        if ($scope.ListTinTuc[i].ID == $scope.t.ID) {
                            $scope.ListTinTuc[i].TieuDe = $scope.t.TieuDe;
                            $scope.ListTinTuc[i].HinhAnh = $scope.t.HinhAnh;
                            $scope.ListTinTuc[i].NoiDung = $scope.t.NoiDung;
                            $scope.ListTinTuc[i].NgayDang = $scope.t.NgayDang;
                            $scope.ListTinTuc[i].TrangThai = $scope.t.TrangThai;
                            break;
                        }
                    }
                    alert("Update success...!")
                }
            }, function (e) { alert(e); });
        }
        else //Thêm tin tức
        {
            $http({
                method: 'POST',
                datatype: 'json',
                url: '/Admin/QLTinTuc/Insert',
                data: JSON.stringify($scope.t)
            }).then(function (d) {
                alert($scope.t.ID);
                if (d.data == "") {
                    $scope.ListTinTuc.push($scope.t);
                    $scope.t = null;
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

    $scope.XoaTinTuc = function (t) {
        $http({
            method: 'Post',
            url: '/Admin/QLTinTuc/Delete',
            datatype: 'Json',
            data: { id: t.ID }
        }).then(function (d) {
            var vt = $scope.ListTinTuc.indexOf(t);
            $scope.ListTinTuc.splice(vt, 1);
        }, function (e) { alert(e) });
    };

    $scope.maxSize = 5;     // Limit number for pagination display number.  
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero  
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->  
    $scope.pageSizeSelected = 5; // Maximum number of items per page.  

    $scope.GetTinTucList = function () {
        $http.get("http://localhost:64769/Admin/QLTinTuc/GetTinTucPT?pageIndex=" + $scope.pageIndex + "&pageSize=" + $scope.pageSizeSelected).then(
            function (response) {
                $scope.ListTinTuc = response.data.TinTucs;
                $scope.totalCount = response.data.totalCount;
            },
            function (err) {
                var error = err;
            });
    }

    //Loading employees list on first time  
    $scope.GetTinTucList();

    //This method is calling from pagination number  
    $scope.pageChanged = function () {
        $scope.GetTinTucList();
    };

    //This method is calling from dropDown  
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.GetTinTucList();
    };  
};



app.controller("LogoutController", function ($scope, $rootScope, $http, $window) {
    $rootScope.Logout = function () {
        $http({
            method: 'Post',
            url: '/Admin/Login/Logout'
        }).then(function () {
            $window.location.href = '/Admin/Login/Index';
        }, function () { });
    };
});


// QUẢN LÝ USER
app.controller("UserController", UserController);
function UserController($scope, $rootScope, $http, $window) {

    $scope.Signup = function () {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/Admin/Signup/Signup',
            data: JSON.stringify($scope.us)
        }).then(function (d) {
            //alert($scope.s.MaSP);
            if (d.data == "") {
                $scope.ListUser.push($scope.us);
                $scope.us = null;
                alert("Đăng ký thành công...!");
            }
            else {
                alert(d.data);
            }
        }, function (e) {
            alert("Lỗi nhập...!");
        });
    };

    //Danh sách user
    $http.get('/Admin/QLUser/GetUsers').then(function (d) {
        $rootScope.ListUser = d.data;
    }, function (error) { alert('Failed'); });

    $scope.Them = function () {
        $scope._function = "Thêm sản phẩm";
        $scope.buttext = "Save";
        $scope.s = null;
    };

   
};




