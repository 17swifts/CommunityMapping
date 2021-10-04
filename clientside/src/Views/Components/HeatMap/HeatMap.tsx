import { useState, useEffect } from 'react';
import MapGL, { Source, Layer } from 'react-map-gl';
import { DataLayer, LineLayer } from './HeatMapStyle';

// Access token for MapBox API
const MAPBOX_TOKEN = "pk.eyJ1IjoiamFtZXN0a2VsbHkiLCJhIjoiY2tzOGU4ejl1MG9icjJ1bzJ2MzV6d2xldSJ9.vFX3vaZcZjWnXnqOoMn2Vg";
const MAP_STYLE = "mapbox://styles/mapbox/light-v10"; // Map Styling

export default function HeatMapTest() {
    // Set viewport options for map
    const [viewport, setViewport] = useState({
        latitude: -30.2744,
        longitude: 133.7751,
        zoom: 4,
        pitch: 30
    });

    const [data, setData] = useState<any | null>(null); // Data set and get object
    const [hoverInfo, setHoverInfo] = useState(null); // TODO: Add hover information

    // Fetch the data globally
    useEffect(() => {
        fetch('https://raw.githubusercontent.com/jamestkelly/CommunityMappingData/main/geo-numeric.json')
            .then(resp => resp.json())
            .then(json => setData(json))
    })
    
    // Render the map component
    return (
        <MapGL
            { ...viewport }
            width="95vw"
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