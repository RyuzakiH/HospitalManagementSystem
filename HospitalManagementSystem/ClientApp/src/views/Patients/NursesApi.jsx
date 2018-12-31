import Axios from 'axios';

class NursesApi {


    static getNurses = (callback) => {
        Axios.get('https://localhost:44350/api/nurses')
            .then(res => callback(res.data))
            .catch(NursesApi.errorHandler);
    }


    static getNurse = (id, callback) => {
        Axios.get('https://localhost:44350/api/nurses/' + id)
            .then(res => callback(res.data))
            .catch(NursesApi.errorHandler);
    }


    static addNurse = (patient, callback) => {
        Axios.post('https://localhost:44350/api/nurses', patient)
            .then(() => NursesApi.getPatients(callback))
            .catch(NursesApi.errorHandler);
    }


    static editNurse = (patient, callback) => {
        let id = patient.id;
        delete patient.id;
        Axios.put('https://localhost:44350/api/nurses/' + id, patient)
            .then(() => NursesApi.getPatients(callback))
            .catch(NursesApi.errorHandler);
    }


    static deleteNurse = (id, callback) => {
        Axios.delete('https://localhost:44350/api/nurses/' + id)
            .then(() => NursesApi.getPatients(callback))
            .catch(NursesApi.errorHandler);
    }


    errorHandler = error => console.log(error);

}


export default NursesApi;
