import axios from "axios";
const api = axios.create({
  baseURL: import.meta.env.VITE_BASE_URL_API,
  headers: {
    "Content-Type": "application/json; charset=utf-8"
  },
});

export default Object.assign({
  get: async function (endpoint) {
    try {
      const response = await api.get(endpoint);

      return response.data;
    } catch (error) {
      console.error("Erro ao buscar dados: ", error);
      throw error;
    }
  },

  post: async function (endpoint, dto) {
    try {
      console.log(api);
      const response = await api.post(endpoint, dto);

      return response.data;
    } catch (error) {
      console.error("Erro ao enviar dados: ", error);
      throw error;
    }
  },

  update: async function (endpoint, dto) {
    try {
      const response = await api.put(endpoint, dto);

      return response.data;
    } catch (error) {
      console.error("Erro ao enviar dados: ", error);
      throw error;
    }
  },

  remove: async function (endpoint) {
    try {
      const response = await api.delete(endpoint);

      return response.data;
    } catch (error) {
      console.error("Erro ao enviar dados: ", error);
      throw error;
    }
  },
});
