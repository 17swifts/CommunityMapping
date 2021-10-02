import { useState, useEffect } from 'react';
import MapGL, { Source, Layer } from 'react-map-gl';
import { DataLayer, LineLayer } from './HeatMapStyle';

const MAPBOX_TOKEN = "pk.eyJ1IjoiamFtZXN0a2VsbHkiLCJhIjoiY2tzOGU4ejl1MG9icjJ1bzJ2MzV6d2xldSJ9.vFX3vaZcZjWnXnqOoMn2Vg";
const MAP_STYLE = "mapbox://styles/mapbox/light-v10";

export default function HeatMapTest() {
    const [viewport, setViewport] = useState({
        latitude: -30.2744,
        longitude: 133.7751,
        zoom: 4,
        pitch: 30
    });

    const [data, setData] = useState<any | null>(null);
    const [hoverInfo, setHoverInfo] = useState(null);

    useEffect(() => {
        fetch('https://raw.githubusercontent.com/jamestkelly/CommunityMappingData/main/geo2.json')
            .then(resp => resp.json())
            .then(json => setData(json))
    })
    
    return (
        <MapGL
            { ...viewport }
            width="100vw"
            height="100vh"
            mapStyle={ MAP_STYLE }
            onViewportChange={ setViewport }
            mapboxApiAccessToken={ MAPBOX_TOKEN }
        >
            <Source type="geojson" data={ data }>
                <Layer {...DataLayer}/>
                <Layer {...LineLayer}/>
            </Source>
        </MapGL>
    );
}