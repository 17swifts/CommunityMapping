import React, { useEffect, useState, useMemo, Component } from 'react';
import 'mapbox-gl/dist/mapbox-gl.css';
import ReactMapGL, { Layer, Source } from 'react-map-gl';

import { MAP_TOKEN } from 'Constants/Tokens';
//import * as d3 from 'd3';


export default function Map() {
    //const mapData = require("../../../../public/data/geo.json");
    const [viewport, setViewport] = useState({
        latitude: -22.164678,
        longitude: 144.5844903,
        width: '100vw',
        height: '93.85vh', // Temporarily hard coded for development
        zoom: 5,
        pitch: 30,
    });
    const [allData, setAllData] = useState(null);
    const [data, setData] = useState(null)

    //const data = d3.json('Packages/Data/geo.json');

    // Fetch the map data from public directory (can be changed to online link)
    useEffect(() => {
        fetch("../../../../public/data/geo.json")
            .then(resp => resp.json())
            .then(json => setAllData(json));
    }, []);

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
                <Source id="qldboundaries" type="geojson" data={"../../../../public/data/geo.json"}/>
                <Layer
                    id="test"
                    type="fill"
                    source="qldboundaries"
                    paint={{
                        'fill-color': '#e32636'
                    }}
                />
            </ReactMapGL>
        </div>
    );
}