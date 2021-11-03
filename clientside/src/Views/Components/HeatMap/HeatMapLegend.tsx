import CSS from 'csstype';

export default function HeatMapLegend() {
    const legendStyle: CSS.Properties = {
        background: "#FFFFFF",
    };

    const legendHeader: CSS.Properties = {
        padding: "5px 0 5px 10px",
        display: "flex",
        alignSelf: "center"
    };

    const legendRow: CSS.Properties = {
        padding: "5px 0",
        display: "flex",
        alignItems: "baseline",
        justifyContent: "space-between"
    };

    const itemText: CSS.Properties = {
        paddingLeft: "5px",
        color: "#474747"
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
        backgroundColor: "#EED086",
        border: "1px solid #000000"
    };

    const boxStyleThree: CSS.Properties = {
        width: "10px",
        height: "10px",
        backgroundColor: "#EFBA77",
        border: "1px solid #000000"
    };

    const boxStyleFour: CSS.Properties = {
        width: "10px",
        height: "10px",
        backgroundColor: "#EFA669",
        border: "1px solid #000000"
    };

    const boxStyleFive: CSS.Properties = {
        width: "10px",
        height: "10px",
        backgroundColor: "#EF9059",
        border: "1px solid #000000"
    };

    const boxStyleSix: CSS.Properties = {
        width: "10px",
        height: "10px",
        backgroundColor: "#EF7A4A",
        border: "1px solid #000000"
    };

    const boxStyleSeven: CSS.Properties = {
        width: "10px",
        height: "10px",
        backgroundColor: "#EF663C",
        border: "1px solid #000000"
    };

    const boxStyleEight: CSS.Properties = {
        width: "10px",
        height: "10px",
        backgroundColor: "#EF522E",
        border: "1px solid #000000"
    };

    const boxStyleNine: CSS.Properties = {
        width: "10px",
        height: "10px",
        backgroundColor: "#F03117",
        border: "1px solid #000000"
    };

    return (
        <div style={ legendStyle }>
            <div style={ legendHeader }>
                <h5>Gap Score</h5>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleOne }> </div>
                <div style={ itemText }>0.00 - 49.99</div>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleTwo }> </div>
                <div style={ itemText }>50.00 - 99.99</div>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleThree }> </div>
                <div style={ itemText }>100.00 - 149.99</div>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleFour }> </div>
                <div style={ itemText }>150.00 - 199.99</div>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleFive }> </div>
                <div style={ itemText }>200.00 - 249.99</div>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleSix }> </div>
                <div style={ itemText }>250.00 - 299.99</div>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleSeven }> </div>
                <div style={ itemText }>300.00 - 349.99</div>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleEight }> </div>
                <div style={ itemText }>350.00 - 399.99</div>
            </div>
            <div style={ legendRow }>
                <div style={ boxStyleNine }> </div>
                <div style={ itemText }>400.00 - 449.99</div>
            </div>
        </div>
    )
}