import Axios from 'axios';

class PatientsApi {


    static getPatients = (callback) => {
        Axios.get('https://localhost:44350/api/patients')
            .then(res => callback(res.data))
            .catch(PatientsApi.errorHandler);
    }


    static getPatient = (id, callback) => {
        Axios.get('https://localhost:44350/api/patients/' + id)
            .then(res => callback(res.data))
            .catch(PatientsApi.errorHandler);
    }


    static admitPatient = (id, callback) => {
        Axios.get('https://localhost:44350/api/patients/' + id + '/admit')
            .then(res => callback(res.data))
            .catch(PatientsApi.errorHandler);
    }


    static dischargePatient = (id, callback) => {
        Axios.get('https://localhost:44350/api/patients/' + id + '/discharge')
            .then(res => callback(res.data))
            .catch(PatientsApi.errorHandler);
    }


    static addPatient = (patient, callback) => {
        Axios.post('https://localhost:44350/api/patients', patient)
            .then(() => PatientsApi.getPatients(callback))
            .catch(PatientsApi.errorHandler);
    }


    static editPatient = (patient, callback) => {
        let id = patient.id;
        delete patient.id;
        Axios.put('https://localhost:44350/api/patients/' + id, patient)
            .then(() => PatientsApi.getPatients(callback))
            .catch(PatientsApi.errorHandler);
    }


    static deletePatient = (id, callback) => {
        Axios.delete('https://localhost:44350/api/patients/' + id)
            .then(() => PatientsApi.getPatients(callback))
            .catch(PatientsApi.errorHandler);
    }


    errorHandler = error => console.log(error);

}


export default PatientsApi;
