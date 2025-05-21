!function () {
    let t = localStorage.getItem("__CONFIG__"), e = document.getElementsByTagName("html")[0], i = Object.assign(JSON.parse(JSON.stringify({
        theme: "light",
        nav: "vertical",
        layout: {mode: "fluid", position: "fixed"},
        topbar: {color: "light"},
        menu: {color: "light"},
        //todo: chỉnh sửa sidenav mặc định tại đây
        //sidenav: {size: "full", user: !0},
        sidenav: {size: "default", user: !0},
    })), t ? JSON.parse(t) : {});
    if (e.setAttribute("data-bs-theme", i.theme), e.setAttribute("data-layout-mode", i.layout.mode), e.setAttribute("data-menu-color", i.menu.color), e.setAttribute("data-topbar-color", i.topbar.color), e.setAttribute("data-layout-position", i.layout.position), "vertical" === i.nav) {
        let a = i.sidenav.size;
        window.innerWidth <= 767 ? a = "full" : 767 <= window.innerWidth && window.innerWidth <= 1140 && "full" !== a && "fullscreen" !== a && (a = "condensed"), e.setAttribute("data-sidenav-size", a), !0 === i.sidenav.user ? e.setAttribute("data-sidenav-user", !0) : e.removeAttribute("data-sidenav-user")
    }
    window.defaultConfig = JSON.parse(JSON.stringify(i)), window.config = i
}();