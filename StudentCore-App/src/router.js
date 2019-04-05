import Vue from 'vue';
import Router from 'vue-router';
import Students from './components/Student/Students'
import Teachers from './components/Teacher/Teachers'

Vue.use(Router);

export default new Router({
   routes: [
       {
           path: '/teacher',
           name: 'Teacher',
           component : Teachers
       },
       {
           path: '/student',
           name: 'Student',
           component : Students
       }
   ]
})
