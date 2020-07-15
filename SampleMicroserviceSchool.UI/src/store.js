import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

// http
var baseAddress = window.location.host;
const schoolService = axios.create({
    baseURL: process.env.NODE_ENV == 'development' ? '//localhost:59851' : `//student.${baseAddress}/`,
});
const incomeService = axios.create({
    baseURL: process.env.NODE_ENV == 'development' ? '//localhost:59885' : `//income.${baseAddress}/`,
});;

Vue.use(Vuex)
const store = new Vuex.Store({
    state: {
        courses: [],
        students: [],
        payments: [],
    },

    getters: {
        courses: (state) => state.courses,
        students: (state) => state.students,
        payments: (state) => state.payments,
    },

    actions: {
        loadCourses({ commit }) {
            schoolService.get('/courses').then(r => {
                commit('setCourses', r.data);
            })
        },
        loadStudents({ commit }) {
            schoolService.get('/students').then(r => {
                commit('setStudents', r.data);
            })
        },
        loadPayments({ commit }) {
            incomeService.get('/payments').then(r => {
                commit('setPayments', r.data);
            })
        },
    },

    mutations: {
        setCourses(state, data) {
            state.courses = data;
        },
        setStudents(state, data) {
            state.students = data;
        },
        setPayments(state, data) {
            state.payments = data;
        },
    },
})

export default store;