function splice(string, value, index) {
    return string.slice(0, index) + value + string.slice(index);
}

function HighlightText(paragraphIndex, startIndex, length, colorRGB) {

    let selector = $('.ImtSelectionArea').children()[paragraphIndex];
    let text = $.trim($(selector).text());
    if (length < 1) {
        length = text.length - startIndex;
    }
    text = splice(text, '</span>', startIndex + length);
    text = splice(text, '<span class="ImtSelected" style="background-color:#' + colorRGB + ';">', startIndex);
    $(selector).html(text);
}

function HighlightPictureArea(relx, rely, width, height, colorRgb) {
    $('.ImtImage').append('<div class="ImtImageHighlight"></div>');
    selector = $('.ImtImageHighlight');
    parentoffset = $('.ImtImage').offset();
    $(selector).offset({ top: parentoffset.top + rely, left: parentoffset.left + relx });
    $(selector).width(width);
    $(selector).height(height);
    $(selector).css('background-color', '#' + colorRgb);
}

function debug() {
    var object = obj();
    object.registerType("a", {
        color: 'ff6666'
    });
    object.registerHighlight("a", { htype: 'text', paragraphIndex: 0, startIndex: 5, length: 5 });
    object.registerHighlight("a", { htype: 'image', relx: 10, rely: 10, width: 40, height: 20 });
    object.changeHighlight("a");
    //HighlightPictureArea(10,10,40,20,'ff6666');
}

function obj() {
    var self = this;
    self.types = [];
    self.highlights = []

    self.registerType = function (type, args) {
        types[type] = { type: type, color: args.color };
    }

    self.registerHighlight = function (type, args) {
        if (args.htype == 'text') {
            self.highlights.push({
                type: type,
                htype: args.htype,
                paragraphIndex: args.paragraphIndex,
                startIndex: args.startIndex,
                length: args.length
            });
        }
        else if (args.htype == 'image') {
            self.highlights.push({
                type: type,
                htype: args.htype,
                relx: args.relx,
                rely: args.rely,
                width: args.width,
                height: args.height
            });
        }
    }

    self.changeHighlight = function (type) {
        $('.ImtSelected').remove();
        if (type === 0) {
            return;
        }
        for (var i = 0; i < self.highlights.length; i++) {
            if (self.highlights[i].type === type) {
                if (self.highlights[i].htype == 'text') {
                    HighlightText(self.highlights[i].paragraphIndex, self.highlights[i].startIndex, self.highlights[i].length, self.types[type].color)
                }
                else if (self.highlights[i].htype == 'image') {
                    HighlightPictureArea(self.highlights[i].relx, self.highlights[i].rely, self.highlights[i].width, self.highlights[i].height, self.types[type].color);
                }
            }
        }
    }


    return self;
}
$(document).ready(function () {
    debug()
});
