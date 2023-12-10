import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7226/",
});

export default api;
