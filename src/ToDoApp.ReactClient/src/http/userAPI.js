export const registration = async (email, password) => {
    const response = await fetch('https://localhost:63131/api/User/Post', {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({Email: email, Password: password})
        });

    if (response.status !== 200){
        return null;
    }

    const data = await response.json();

    return data;
}

export const getCurrentUser =  async () => {
    const response = await fetch('https://localhost:63131/api/User/Get', {
        method: 'GET',
        credentials: 'include'
    }); 

    if (response.status !== 200){
        return null;
    }

    const data = await response.json();

    return data;
};