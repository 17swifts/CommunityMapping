// Component to embed the Community Mapping page to the new platform
export default function Map() {
    // Fetch the map
    return (
        <div style={{ "width": "95%", "height": "100%" }}> 
            <embed src="https://community-map-3418c.web.app/" style={{ "width": "100%", "height": "100%" }}/>
        </div>
    )
} 