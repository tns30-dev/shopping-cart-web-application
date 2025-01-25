window.onload = function () {
    initForm();
}

function initForm() {
    let form_elem = document.getElementById("loginform");

    if (!form_elem) {
        return;
    }

    form_elem.addEventListener("submit", onFormSend);
}

function onFormSend(event) {
    var username = document.getElementById("username");
    var password = document.getElementById("password");
    var passHash = document.getElementById("passHash");

    if (!username || !password || !passHash) {
        console.log("Fields not found. Preventing default.");
        event.preventDefault();
        return;
    }

    if (username.value.trim() === "" || password.value.trim() === "") {
        let msg = "All input fields must be filled.";
        showMsg(true, msg);
        event.preventDefault();
        return;
    }

    showMsg(false);
    let hash = CryptoJS.SHA1(password.value);
    passHash.value = hash.toString();
}

function showMsg(is_visible, msg) {
    let msg_elem = document.getElementById("errorMessage");

    if (!msg_elem) {
        return;
    }

    if (is_visible) {
        msg_elem.innerHTML = msg;
        msg_elem.style.display = "block";
    }
    else {
        msg_elem.style.display = "none";
    }
}

/*
function checkIsUserPasswordOkay(username, passHash) {
    let xhr = new XMLHttpRequest();

    xhr.open("POST", "/Login/UserPasswordValidation");
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onreadystatechange = function () {
        // wait for AJAX to complete
        if (this.readyState === XMLHttpRequest.DONE) {
            // checks if the underlying http transfer was successful
            if (this.status === 200) {
                // Try to parse the JSON string into a JavaScript object
                let data = JSON.parse(this.responseText);

                if (data.isSuccess === false) {
                    let msg = "Incorrect username and password";
                    showMsg(true, msg);
                    userpasswordChecker = false;

                    // Prevent form submission
                    event.preventDefault();
                } else {
                    // Redirect using JavaScript
                    if (data.isSuccess === true) {
                        showMsg(false);
                        userpasswordChecker = true;
                        window.location.href = data.redirectUrl;
                    }
                }
            }
        }
    };

    xhr.send("username=" + username + "&passHash=" + passHash);
} /*





/*
repository code for future usage
window.onload = function () {
    initForm();
    initUsernameTextbox();
}


function initForm() {
    let form_elem = document.getElementById("loginform");

    if (!form_elem) {
        return;
    }

    form_elem.addEventListener("submit", onFormSend);
}


function initUsernameTextbox() {
    let userelement = document.getElementById("username");

    if (!userelement) {
        return;
    }

    userelement.addEventListener("blur", function () {
        if (userelement.value.trim() === "") {
            return;
        }

        // make a AJAX request to our server to check
        checkIsUsernameOkay(userelement.value);
    });

    userelement.addEventListener("focus", function () {
        showMsg(false);
    });
    //this method is to retrieve back the error
}

function checkIsUsernameOkay(username) {
    let xhr = new XMLHttpRequest();

    xhr.open("POST", "/Login/UserNameValid");
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onreadystatechange = function () {
        // wait for AJAX to complete
        if (this.readyState === XMLHttpRequest.DONE) {
            // checks if the underlying http transfer was successful
            if (this.status !== 200) {
                return;
            }

            // parse the JSON string into a JavaScript object
            let data = JSON.parse(this.responseText);

            // access the JavaScript object
            if (data.isUserNameValid === false) {
                let msg = "Username cannot be found";
                showMsg(true, msg);
            }
        }
    }
    xhr.send("username=" + username);
}


isUserValid = false;

function onFormSend(event) {
    let username = document.getElementById("username");
    let password = document.getElementById("password");
    let hashPassword = document.getElementById("passHash");

    if (!username || !password || !hashPassword) {
        return false;
    }

    if (username.value.trim() === "" || password.value.trim() === "") {
        let msg = "All input fields must be filled.";
        showMsg(true, msg);
        event.preventDefault();
        return;  // Exit early if fields are empty
    }

    let hash = CryptoJS.SHA1(password.value);
    hashPassword.value = hash.toString();

    checkIsUserPasswordOkay(username.value, hash.toString());

    // Prevent form submission here
    event.preventDefault();
}

function checkIsUserPasswordOkay(username, passHash) {
    let xhr = new XMLHttpRequest();

    xhr.open("POST", "/Login/UserPasswordValidation");
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

    xhr.onreadystatechange = function () {
        // wait for AJAX to complete
        if (this.readyState === XMLHttpRequest.DONE) {
            // checks if the underlying http transfer was successful
            if (this.status === 200) {
                // Try to parse the JSON string into a JavaScript object
                let data = JSON.parse(this.responseText);

                if (data.isSuccess === false) {
                    let msg = "Incorrect username and password";
                    showMsg(true, msg);
                } else {
                    // Redirect using JavaScript
                    if (data.isSuccess === true) {
                        window.location.href = data.redirectUrl;
                    }
                }
            }
        }
    };

    xhr.send("username=" + username + "&passHash=" + passHash);
}


function showMsg(is_visible, msg) {
    let msg_elem = document.getElementById("errorMessage");

    if (!msg_elem) {
        return;
    }

    if (is_visible) {
        msg_elem.innerHTML = msg;
        msg_elem.style.display = "block";
    }
    else {
        msg_elem.style.display = "none";
    }
}*/

