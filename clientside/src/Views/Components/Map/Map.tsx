import React, { useState } from 'react';
import 'mapbox-gl/dist/mapbox-gl.css';
import ReactMapGL, { Layer, Source } from 'react-map-gl';

import { MAP_TOKEN } from 'Constants/Tokens';
import * as mapData from 'Packages/Data/geo.json';
import * as d3 from 'd3';

export default function Map() {
    const [viewport, setViewport] = useState({
        latitude: -22.164678,
        longitude: 144.5844903,
        width: '100vw',
        height: '93.85vh', // Temporarily hard coded for development
        zoom: 5,
        pitch: 30,
    });

    const data = d3.json('Packages/Data/geo.json');

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
                <Source id="qldboundaries" type="geojson" data={ data }/>
                <Layer
                    id="test"
                    type="fill"
                    source="qldboundaries"
                    paint={{'fill-color': '#228b22', 'fill-opacity': 0.4}}
                />
            </ReactMapGL>
        </div>
    );
}