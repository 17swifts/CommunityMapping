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

export const LineLayer = {
    'id': 'seifa-outline',
    'type': 'line' as 'line',
    'layout': {},
    'paint': {
        'line-color': '#000',
        'line-width': 2
    }
}