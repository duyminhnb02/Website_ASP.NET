if (window.location.href != "http://localhost:50077/Cart/AddToCart?productID=-1") {
    window.addEventListener("load", () => {
        location.replace("http://localhost:50077/Cart/AddToCart?productID=-1");
    })
}