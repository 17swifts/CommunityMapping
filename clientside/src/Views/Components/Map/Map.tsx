import React, { useState } from 'react';
import 'mapbox-gl/dist/mapbox-gl.css';
import ReactMapGL from 'react-map-gl';

import { MAP_TOKEN } from 'Constants/Tokens';

export default function Map() {
    const [viewport, setViewport] = useState({
        latitude: -22.164678,
        longitude: 144.5844903,
        width: '100vw',
        height: '93.85vh', // Temporarily hard set for development
        zoom: 5,
        pitch: 30,
    });

    return (
        <div>
            <ReactMapGL
                {...viewport}
                mapboxApiAccessToken = { MAP_TOKEN }
                mapStyle = "mapbox://styles/mapbox/dark-v10"
                onViewportChange = {(viewport: any) => {
                    setViewport(viewport);
                }}
            >
                Markers here
            </ReactMapGL>
        </div>
    );
}