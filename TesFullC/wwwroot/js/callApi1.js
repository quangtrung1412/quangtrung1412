const URI = "/api";

async function callApi1(endpoint, method = "GET", body = null) {
    const resp = await fetch(URI + "/" + endpoint, {
        method,
        headers: {
            "Content-Type": "application/json"
        },
        body
    });
    return await resp.json();
}
export default callApi1