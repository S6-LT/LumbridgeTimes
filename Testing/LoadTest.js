import http from 'k6/http';
import { sleep } from 'k6';
export const options = {
    stages: [
        { duration: '5s', target: 10 },
        { duration: '30s', target: 10 },
        { duration: '5s', target: 40 },
        { duration: '30s', target: 40 },
        { duration: '5s', target: 20 },
        { duration: '30s', target: 20 },
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