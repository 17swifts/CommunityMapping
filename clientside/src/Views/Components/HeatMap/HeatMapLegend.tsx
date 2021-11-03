import * as React from 'react';
import CSS from 'csstype';

export default function HeatMapLegend() {
    const legendStyle: CSS.Properties = {
        background: "#FFFFFF",
        alignContent: "center"
    };

    const legendRow: CSS.Properties = {
        display: "flex",
        padding: "10px 0"
    };

    const itemText: CSS.Properties = {
        paddingLeft: "5px"
    };

    const boxStyleOne: CSS.Properties = {
        width: "10px",
        height: "10px",
        backgroundColor: "#EEE695",
        border: "1px solid #000000"
    };

    const boxStyleTwo: CSS.Properties = {
        width: "10px",
        height: "10px",
        backgroundColor: "#EED086"
    };

    return (
        <div style={ legendStyle }>
            <h5>Gap Score</h5>
            <div style={ legendRow }>
                <div style={ boxStyleOne }> </div>
                <div style={ itemText }>0.00 - 49.99</div>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleTwo }> </div>
                <div style={ itemText }>50.00 - 99.99</div>
            </div>
        </div>
    )
}