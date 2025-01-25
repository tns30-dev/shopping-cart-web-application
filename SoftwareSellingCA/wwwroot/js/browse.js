function addToCart(productId) {
    let xhr = new XMLHttpRequest();

    xhr.open("POST", "/Browse/ChosenProducts");
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE) {
            if (this.status === 200) {
                let data = JSON.parse(this.responseText);

                if (data.success === true) {
                    alert('Product added to cart');

                    // Update cart count element on the page
                    updateCartCount();
                } else {
                    alert('Failed to add product to cart');
                }
            }
        }
    };

    xhr.send("ProductId=" + productId);
}

function updateCartCount() {
    fetch('/Browse/GetCartCount')
        .then(response => response.json())
        .then(data => {
            // Update cart count inside the then block
            document.querySelector('.cart-count').innerText = data.count;
        })
        .catch(error => {
            console.error('Error fetching cart count:', error);
        });
}


