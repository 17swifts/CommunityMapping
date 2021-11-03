export const DataLayer = {
    id: 'seifa',
    type: 'fill' as 'fill',
    paint: {
        "fill-color": {
            property: "sa3Id" as "sa3Id",
            stops: [
                [0, '#3288bd'],
                [10000, '#66c2a5'],
                [20000, '#abdda4'],
                [30000, '#e6f598'],
                [40000, '#ffffbf'],
                [50000, '#fee08b'],
                [60000, '#fdae61'],
                [70000, '#f46d43'],
                [80000, '#d53e4f'],
                
            ]
        }
    }
}

export const HeatLayer = {
    id: 'data',
    type: 'fill' as 'fill',
    paint: {
        "fill-color": {
            property: "gapScore" as "gapScore",
            stops: [
                [0, "#EEE695"],
                [5, "#EEE493"],
                [10, "#EEE292"],
                [15, "#EEDF90"],
                [20, "#EEDD8F"],
                [25, "#EEDB8D"],
                [30, "#EED98C"],
                [35, "#EED78A"],
                [40, "#EED489"],
                [45, "#EED287"],
                [50, "#EED086"],
                [55, "#EECE84"],
                [60, "#EECC83"],
                [65, "#EEC981"],
                [70, "#EEC780"],
                [75, "#EFC57E"],
                [80, "#EFC37D"],
                [85, "#EFC07B"],
                [90, "#EFBE7A"],
                [95, "#EFBC78"],
                [100, "#EFBA77"],
                [105, "#EFB875"],
                [110, "#EFB574"],
                [115, "#EFB372"],
                [120, "#EFB171"],
                [125, "#EFAF6F"],
                [130, "#EFAD6E"],
                [135, "#EFAA6C"],
                [140, "#EFA86B"],
                [145, "#EFA669"],
                [150, "#EFA669"],
                [155, "#EFA467"],
                [160, "#EFA266"],
                [165, "#EF9F64"],
                [170, "#EF9D63"],
                [175, "#EF9B61"],
                [180, "#EF9960"],
                [185, "#EF975E"],
                [190, "#EF945D"],
                [195, "#EF925B"],
                [200, "#EF9059"],
                [205, "#EF8E58"],
                [210, "#EF8C56"],
                [215, "#EF8955"],
                [220, "#EF8753"],
                [225, "#EF8552"],
                [230, "#EF8350"],
                [235, "#EF804F"],
                [240, "#EF7E4D"],
                [245, "#EF7C4C"],
                [250, "#EF7A4A"],
                [255, "#EF7848"],
                [260, "#EF7547"],
                [265, "#EF7345"],
                [270, "#EF7144"],
                [275, "#EF6F42"],
                [280, "#EF6D41"],
                [285, "#EF6A3F"],
                [290, "#EF683E"],
                [295, "#EF663C"],
                [300, "#EF663C"],
                [305, "#EF643B"],
                [310, "#EF6239"],
                [315, "#EF6038"],
                [320, "#EF5E36"],
                [325, "#EF5C35"],
                [330, "#EF5A34"],
                [335, "#EF5832"],
                [340, "#EF5631"],
                [345, "#EF5430"],
                [350, "#EF522E"],
                [355, "#EF502D"],
                [360, "#EF4E2B"],
                [365, "#EF4A28"],
                [370, "#EF4726"],
                [375, "#EF4323"],
                [380, "#EF3F21"],
                [385, "#F03C1E"],
                [390, "#F0381C"],
                [395, "#F03419"],
                [400, "#F03117"],
                [405, "#F02D14"]
            ]
        }
    }
}

export const HighlightHeatMapLayer ={
    id: 'data-highlight',
    type: 'fill' as 'fill',
    paint: {
        'fill-color': '#808080',
        'fill-opacity': 0.3
    }
};

export const LineLayer = {
    'id': 'seifa-outline',
    'type': 'line' as 'line',
    'layout': {},
    'paint': {
        'line-color': '#000',
        'line-width': 2
    }
}