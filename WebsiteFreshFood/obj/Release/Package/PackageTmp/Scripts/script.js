//Khi người dùng cuộn chuột thì gọi hàm scrollFunction
window.onscroll = function () {
    scrollFunction()
};
// khai báo hàm scrollFunction
function scrollFunction() {
    // Kiểm tra vị trí hiện tại của con trỏ so với nội dung trang
    if (document.body.scrollTop > 200 || document.documentElement.scrollTop > 200) {
        //nếu lớn hơn 200px thì hiện button
        document.getElementById("scrollToTop").style.display = "block";
    }
    else {
        //nếu nhỏ hơn 200px thì ẩn button
        document.getElementById("scrollToTop").style.display = "none";
    }
}

function scrollToTop() {
    var position = document.body.scrollTop || document.documentElement.scrollTop;
    if (position) {
        window.scrollBy(0, -Math.max(1, Math.floor(position / 10)));
        scrollAnimation = setTimeout("scrollToTop()", 30);
    }
    else clearTimeout(scrollAnimation);
}

document.addEventListener("DOMContentLoaded", function () {
    //bat su kien cuon chuot
    var trangthai = 'duoi300';
    //lay ve menu
    var doituongmenu = document.querySelector('.menu');
    window.addEventListener('scroll', function () {
        if (window.pageYOffset > 200) {
            if (trangthai == "duoi300") {
                trangthai = 'tren300';
                doituongmenu.classList.add('thulai');
            }
        }
        else if (window.pageYOffset <= 200) {
            if (trangthai == 'tren300') {
                doituongmenu.classList.remove('thulai');
                trangthai = 'duoi300';
            }
        }
    })
}, false)
// PHẦN LIÊN HỆ

function KiemTra() {

    // Kiểm tra tên
    ten = formLienHe.txtTen.value;
    var format = /^[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]*$/;

    if (ten == "") {
        alert("Tên không được trống");
        formLienHe.ten.focus();
        return;
    }

    if (!isNaN(ten)) {
        alert("Tên không chứa ký tự số ");
        formLienHe.txtTen.focus();
        return;
    }
    if (ten.match(format)) {
        alert("Tên không được chứa ký tự đặc biệt");
        formLienHe.ten.focus();
        return true;
    }

    // Kiểm tra email

    var mail = document.getElementById("email").value;
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    kq = filter.test(mail);
    if (mail == "") {
        alert("Email không được bỏ trống !");
        document.email.focus();
        return;
    }

    if (!kq) {
        alert("Hay nhap dia chi email hop le.\nExample@gmail.com");
        document.email.focus();
        return;
    }

    // Kiểm tra comment
    var comment = document.getElementById("txtBinhLuan").value;
    if (comment == "") {
        alert("Bình luận không được trống !");
        document.txtBinhLuan.focus();
        return;
    }
}

function Cong() {
    var count = parseInt(document.getElementById('Quantity').value);
    count = isNaN(count) ? 0 : count;
    count++;
    document.getElementById('Quantity').value = count;
}

function Tru() {
    var count = parseInt(document.getElementById('Quantity').value);
    count = isNaN(count) ? 0 : count;
    count--;
    document.getElementById('Quantity').value = count;
}


