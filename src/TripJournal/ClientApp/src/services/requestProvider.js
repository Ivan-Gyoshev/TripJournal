import authService from '../components/api-authorization/AuthorizeService';

const request = async (method, url, data) => {
    try {
        const token = await authService.getAccessToken();
      
        let headers = {}

        if (token) {
          headers['Authorization'] = `Bearer ${token}`;
        }

        let buildRequest;

        if (method === 'GET') {
            buildRequest = fetch(url, { headers });
        } else {
            buildRequest = fetch(url, {
                method,
                headers: {
                    ...headers,
                    'content-type': 'application/json'
                },
                body: JSON.stringify(data)
            });
        }
        const response = await buildRequest;

        console.log(response);

        const result = await response.json();

        return result;
    } catch (error) {
        console.log(error);
    }
};

export const get = request.bind({}, 'GET');
export const post = request.bind({}, 'POST');
export const patch = request.bind({}, 'PATCH');
export const put = request.bind({}, 'PUT');
export const del = request.bind({}, 'DELETE');