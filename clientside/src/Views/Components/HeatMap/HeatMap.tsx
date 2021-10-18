import useWindowDimensions from 'Hooks/useWindowDimensions';
import mapboxgl from 'mapbox-gl';
import { useState, useEffect, useCallback } from 'react';
import MapGL, { Source, Layer } from 'react-map-gl';
import { DataLayer, LineLayer, HeatLayer } from './HeatMapStyle';

// Access token for MapBox API
const MAPBOX_TOKEN = "pk.eyJ1IjoiamFtZXN0a2VsbHkiLCJhIjoiY2tzOGU4ejl1MG9icjJ1bzJ2MzV6d2xldSJ9.vFX3vaZcZjWnXnqOoMn2Vg";
const MAP_STYLE = "mapbox://styles/mapbox/light-v10"; // Map Styling

function round(num: number) {
    var m = Number((Math.abs(num) * 100).toPrecision(15));
    return Math.round(m) / 100 * Math.sign(num);
}

export default function HeatMapTest() {
    const { height, width } = useWindowDimensions();

    if (width < 700 || height < 600) {
        var zoomNum = 2;
    }
    else if (width > 700 && width < 1200 || height > 600 && height < 800) {
        var zoomNum = 3;
    }
    else {
        var zoomNum = 4;
    }
    // Set viewport options for map
    const [viewport, setViewport] = useState({
        latitude: -30.2744,
        longitude: 133.7751,
        zoom: zoomNum,
        pitch: 30
    });

    const [data, setData] = useState<any | null>(null); // Data set and get object
    const [hoverInfo, setHoverInfo] = useState<any | null>(null); // Hover info object

    // Fetch the data globally
    useEffect(() => {
        fetch('https://raw.githubusercontent.com/jamestkelly/CommunityMappingData/main/data/geo-numeric.json')
            .then(resp => resp.json())
            .then(json => setData(json))
    });

    const onHover = useCallback(event => {
        const {
            features,
            srcEvent: { offsetX, offsetY}
        } = event;
        const hoveredFeature = features && features[0];

        setHoverInfo(
            hoveredFeature
                ? {
                    feature: hoveredFeature,
                    x: offsetX,
                    y: offsetY
                }
                : null
        );
    }, []);

    // Render the map component
    return (
        <MapGL
            { ...viewport }
            width="100%"
            height="100vh"
            mapStyle={ MAP_STYLE }
            onViewportChange={ setViewport }
            mapboxApiAccessToken={ MAPBOX_TOKEN }
            interactiveLayerIds={ [data] }
            onHover={ onHover }
        >
            
            <Source type="geojson" data={ data }>
                <Layer {...HeatLayer}/>
            </Source>
            {hoverInfo && (
                <div className="tooltip" style={{ left: hoverInfo.x, top: hoverInfo.y }}>
                    <div>SA2 Name: { hoverInfo.feature.properties.sa2Name }</div>
                    <div>SA3 Name: { hoverInfo.feature.properties.sa3Name }</div>
                    <div>State: { hoverInfo.feature.properties.stateName }</div>
                    <div>Gap Score: { round(hoverInfo.feature.properties.gapScore) }</div>
                </div>
            )}
        </MapGL>
    );
}