export const registration = async (email, password) => {
    const response = await fetch('https://localhost:50858/api/User/Post', {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({Email: email, Password: password})
        });
    return response;
}