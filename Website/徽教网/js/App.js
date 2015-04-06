/*切换城市*/
function Change() {
    var Content = document.getElementById('position');
    Content.innerHTML = " 切换城市 ";
}
function Back() {
    var Content = document.getElementById('position');
    Content.innerHTML = " 当前城市 ";
}

/*收藏本站*/
function AddFavorite(sURL, sTitle) {
    sURL = encodeURI(sURL);
    try {
        window.external.addFavorite(sURL, sTitle);
    }
    catch (e) {
        try {
            window.sidebar.addPanel(sTitle, sURL, "");
        } catch (e) {
            alert("加入收藏失败,请使用Ctrl+D进行添加,或手动在浏览器里进行设置.");
        }
    }
}

/*幻灯切换*/
function slide() {
    this.uid = slideHelper.getId();
    slideHelper.instance[this.uid] = this;
    this._$ = function (id) { return document.getElementById(id); };
    this.width = 400;//宽度
    this.height = 300;//高度
    this.picWidth = 15;//小图宽度
    this.picHeight = 12;//小图高度
    this.autoplayer = 4;//自动播放间隔（秒）
    this.target = "_blank";
    this._slide = [];
    this._curIndex = 0;
}
slide.prototype =
{
    _createMainslide: function () {
        var flashslideWidth = this.width * this._slide.length + 5;
        var html = "<div id='" + this.uid + "_mainslide' class='mainslide'  style='width:" + (this.width) + "px;height:" + (this.height + 2) + "px;'>";
        html += "<div id='" + this.uid + "_flashslide' class='flashslide' style='width:" + flashslideWidth + "px;height:" + (this.height + 2) + "px;'></div>";
        html += "<div id='" + this.uid + "_imageslide' class='imageslide' style='width:" + this.width + "px;height:" + (this.picHeight + 2) + "px;top:-" + (this.picHeight + 20) + "px;'></div>";
        html += "</div>";
        document.write(html);
    },
    _init: function () {
        var picstyle = "";
        var eventstr = "slideHelper.instance['" + this.uid + "']";
        var imageHTML = "";
        var flashslide = "";
        for (var i = 0; i < this._slide.length; i++) {
            var parame = this._slide[i];
            flashslide += this.flashHTML(parame.url, this.width, this.height, i);
            imageHTML = "<div class='bitdiv " + ((i == 0) ? "curimg" : "defimg") + "' title =" + parame.title + " " + picstyle + " onclick = \"" + eventstr + ".clickPic(" + i + ")\"  onmouseover=\"" + eventstr + ".mouseoverPic(" + i + ")\"></div>" + imageHTML;
        }
        this._$(this.uid + "_flashslide").innerHTML = flashslide;
        this._$(this.uid + "_imageslide").innerHTML = imageHTML;

    },
    _play: function () {
        clearInterval(this._autoplay);
        var idx = this._curIndex + 1;
        if (idx >= this._slide.length) { idx = 0; }
        this.changeIndex(idx);
        var eventstr = "slideHelper.instance['" + this.uid + "']._play()";
        this._autoplay = setInterval(eventstr, this.autoplayer * 1000);

    },
    flashHTML: function (url, width, height, idx) {
        var isFlash = url.substring(url.lastIndexOf('.') + 1).toLowerCase() == "swf";
        var html = "";
        if (isFlash) {
            html = "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' "
            + "codebase='http://download.adobe.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='" + width + "' height='" + height + "'>"
            + "<param name=\"movie\" value=\"" + url + "\" />"
            + "<param name='quality' value='high' />"
            + "<param name='wmode' value='transparent'>"
            + "<embed src='" + url + "' quality='high' wmode='opaque' pluginspage='http://www.adobe.com/go/getflashplayer'"
            + "  type='application/x-shockwave-flash' width=" + width + " height='" + height + "'></embed>"
            + "  </object>";
        } else {
            var eventstr = "slideHelper.instance['" + this.uid + "']";
            var style = "";
            if (this._slide[idx].href) {
                style = "cursor:pointer"
            }
            html = "<img src='" + url + "' style='width:" + width + "px;height:" + height + "px;" + style + "' onclick = \"" + eventstr + ".clickPic(" + idx + ")\"/>";
        }
        return html;
    },
    changeIndex: function (idx) {
        var parame = this._slide[idx];
        moveElement(this.uid + "_flashslide", -(idx * this.width), 1);
        var imgs = this._$(this.uid + "_imageslide").getElementsByTagName("div");
        imgs[this._slide.length - 1 - this._curIndex].className = "bitdiv defimg";
        imgs[this._slide.length - 1 - idx].className = "bitdiv curimg";
        this._curIndex = idx;
    },
    mouseoverPic: function (idx) {
        this.changeIndex(idx);
        if (this.autoplayer > 0) {
            clearInterval(this._autoplay);
            var eventstr = "slideHelper.instance['" + this.uid + "']._play()";
            this._autoplay = setInterval(eventstr, this.autoplayer * 1000);
        }
    },
    clickPic: function (idx) {
        var parame = this._slide[idx];
        if (parame.href && parame.href != "") {
            window.open(parame.href, this.target);
        }
    },
    add: function (imgParam) {
        this._slide[this._slide.length] = imgParam;
    },
    show: function () {
        this._createMainslide();
        this._init();
        if (this.autoplayer > 0) {
            var eventstr = "slideHelper.instance['" + this.uid + "']._play()";
            this._autoplay = setInterval(eventstr, this.autoplayer * 1000);
        }
    }
}
var slideHelper =
{
    count: 0,
    instance: {},
    getId: function () { return '__slide-' + (this.count++); }
};

function moveElement(elementID, final_x, interval) {
    if (!document.getElementById) return false;
    if (!document.getElementById(elementID)) return false;
    var elem = document.getElementById(elementID);
    if (elem.movement) {
        clearTimeout(elem.movement);
    }
    if (!elem.style.left) {
        elem.style.left = "0px";
    }
    var xpos = parseInt(elem.style.left);
    if (xpos == final_x) {
        return true;
    }
    if (xpos < final_x) {
        var dist = Math.ceil((final_x - xpos) / 5);
        xpos = xpos + dist;
    }
    if (xpos > final_x) {
        var dist = Math.ceil((xpos - final_x) / 5);
        xpos = xpos - dist;
    }
    elem.style.left = xpos + "px";
    var repeat = "moveElement('" + elementID + "'," + final_x + "," + interval + ")";
    elem.movement = setTimeout(repeat, interval);
}