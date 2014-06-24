// some helper functions to make manipulating svg with less typing.
// requires d3.js
(function () {    
    var shapes = {
        circle: { name: 'circle', attr: { 'cx': {}, 'cy': {}, 'r': {} } },
        rect:     {name:'rect', attr:{'width': {}, 'height': {}, 'x': {}, 'y': {}} },
        line:     {name:'line', attr:{'x1': {}, 'x2': {}, 'y1': {}, 'y2': {}} },
        polygon:  {name:'polygon', 'attr':{'points': {}} },
        polyline: {name:'polyline', 'attr':{'points': {}} },
        path:     {name:'path', 'attr':{'d': {}} },
        text:     {name: 'text', 'attr': { 'x': {}, 'y': {} }, 'value': {}}
    };
    var exports = {
        setAttrs: function (e, options) {
            for (var k in options) {
                if (!options.hasOwnProperty(k)) continue;
                e.attr(k, options[k]);
            }
        },
        shapes: shapes
    };
    d3.svgHelper=exports;
})(d3)