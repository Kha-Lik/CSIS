import logger from "./logService";
import {toast} from "react-toastify";
import apiEndpoint from "../config.json";
import axios from "axios";

const {apiUrl} = apiEndpoint;

const instance = axios.create({baseURL: apiUrl});

const http = {
    get: instance.get,
    post: instance.post,
    put: instance.put,
    delete: instance.delete,
};

export default http;
