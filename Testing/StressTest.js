import http from 'k6/http';
import { sleep } from 'k6';
export const options = {
    stages: [
        { duration: '5s', target: 5 },
        { duration: '30s', target: 5 },
        { duration: '5s', target: 40 },
        { duration: '30s', target: 40 },
        { duration: '5s', target: 150 },
        { duration: '30s', target: 150 },
        { duration: '5s', target: 250 },
        { duration: '30s', target: 250 },
        { duration: '5s', target: 0 },
    ],
    thresholds: {
        http_req_duration: ['p(95)<600'],
    },
};
export default () => {
    http.get('https://localhost:7202/message/getall');
    sleep(1);
};