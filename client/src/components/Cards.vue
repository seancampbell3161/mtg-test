<template>
    <div class="container">
        <ul>
            <li v-for="card in cards">{{ card }}</li>
        </ul>
    </div>
</template>

<script lang="ts">
    export default {
        mounted() {
            console.log('mounted');
        },
        data() {
            return {
                cards: ['air','fire','water','earth']
            }
        }
    }
</script>


