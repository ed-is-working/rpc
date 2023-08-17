let signInForm = document.getElementById('signInForm');
let signUpForm = document.getElementById('signUpForm');

// let signOutForm = document.getElementById('signOutForm');

const showMessageAndClear = (message, redirectURL) => {

    document.getElementById('FormResponseMessage').innerHTML = message;
    document.getElementById('user').value = "";
    document.getElementById('pass').value = "";
    // alert(message);
    let showMsgDelay = window.setTimeout((redirectURL) => {
        console.log("Clearing message");
        console.log(redirectURL);
        window.clearTimeout(showMsgDelay);
        document.getElementById('FormResponseMessage').innerHTML = "";
        if(redirectURL != null){
            console.log("Redirecting to " + redirectURL);
            redirectURL = redirectURL.toString();
            window.location.href = redirectURL;
        }



    }, 3000, redirectURL);


}

const checkForBlank = (user, pass) => { 

    if(!user || !pass)
    {
        document.getElementById('FormResponseMessage').innerHTML = "Please fill in all fields";
        return false;
    }

    return true;

};

const loginUser = (user, pass) => {
    console.log

    let requestBody = {
        "username": user,
        "password": pass,
    };
    let fetchResult = fetch('http://localhost:5015/Auth/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'accept': 'text/plain'
        },
        body: JSON.stringify(requestBody)

    }).then(response => {
        return response.json();
    }).then(result => {
        console.log(result);
        let token = result.data;
        
        if(token != null && result.success == true){
            localStorage.setItem('token', token);
            localStorage.setItem('username', user);

            showMessageAndClear("Login Successful...redirecting", "http://localhost:5015/Home/index.html");
        
        } else if(token == null && result.success == false){
            showMessageAndClear(result.message, null);
            return result;
        }

        return result;
    }).catch(error => {
        console.log("A non-app error occured. the details are: \n");
        console.log(error);
        return error;
    });
};

const registerUser = (user, pass, email) => {
    let requestBody = {
        "username": user,
        "password": pass,
        "email": email
    };
    let fetchResult = fetch('http://localhost:5015/Auth/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'accept': 'text/plain'
        },
        body: JSON.stringify(requestBody)

    }).then(response => {
        return response.json();
    }).then(result => {
        console.log(result);
        let token = result.data;
        
        if(token != null && result.success == true){
            localStorage.setItem('token', token);
            localStorage.setItem('username', user);

            showMessageAndClear("Registration Successful...redirecting", "http://localhost:5015/Home/index.html");
        
        } else if(token == null && result.success == false){
            showMessageAndClear(result.message, null);
            return result;
        }

        return result;
    }).catch(error => {
        console.log("A non-app error occured. the details are: \n");
        console.log(error);
        return error;
    });
};

signUpForm.addEventListener('submit', (e) =>{
    console.log("signUpForm submitted");
    e.preventDefault();
    let signUpUser = document.getElementById('signUpUser').value;
    let signUpPass = document.getElementById('signUpPass').value;
    let signUpPassRepeat = document.getElementById('signUpPassRepeat').value;
    let signUpEmail = document.getElementById('signUpEMail').value;
    let isNotBlank = false;
    
    if(!signUpUser || !signUpPass || !signUpPassRepeat || !signUpEmail){
        showMessageAndClear("Please fill in all fields", null);
        return;
    } else if(signUpPass != signUpPassRepeat){
        showMessageAndClear("Passwords do not match", null);
        return;
    } else {
        registerUser(signUpUser, signUpPass, signUpEmail)
    }





});

signInForm.addEventListener('submit', (e) => 
{
    e.preventDefault();
    let user = document.getElementById('user').value;
    let pass = document.getElementById('pass').value;
    let isNotBlank = false;

    isNotBlank = checkForBlank(user, pass);
    
    console.log(isNotBlank);

    if(isNotBlank){
        // create fetch() request to server
        loginUser(user, pass);
    } else {
        console.log("All fields are required");
        showMessageAndClear("All fields are required", null);
    }

/* 
    auth.signInWithEmailAndPassword(email, password)
        .then(() => {
            signInForm.reset();
            $('#signInModal').modal('hide');
        })
        .catch(error => {
            console.log(error);
            document.getElementById('signInError').innerHTML = error.message;
        });
*/
});