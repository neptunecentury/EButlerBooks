<template>
  
    <v-card color="blue-lighten-2" elevation="12">

      <v-card-text>
        <v-row>
          <v-col :cols="3">
            <v-img class="bg-white" :aspect-ratio="1" src="https://cdn.vuetifyjs.com/images/parallax/material.jpg"
              cover></v-img>
          </v-col>
          <v-col cols="auto">
            I've been writing since 2005. Yada Yada.
          </v-col>
        </v-row>


      </v-card-text>

    </v-card>

    <div>
      <h2>Check out some of my works</h2>
    </div>

    <div class="d-flex mt-5">
      <v-row>
        <v-col v-for="book in books" :cols="xs ? 12 : 4">
          <v-card elevation="12">

            <v-card-title>
              {{ book.title }}
            </v-card-title>

            <v-img class="bg-white" width="100%"
              :src="`/covers/${book.thumbImageUrl ? book.thumbImageUrl : 'no-cover.png'}`" cover></v-img>

            <v-card-Text>
              <p>{{ book.description }}</p>
              
              <v-chip class="mt-2 mr-2" v-for="genre in book.genres" :text="genre.name"></v-chip>
            </v-card-Text>

            

          </v-card>
        </v-col>
      </v-row>
    </div>

</template>

<script lang="ts" setup>
import axios from 'axios'
import { ref } from 'vue'
import { Book } from '@/interfaces/models'
import { useDisplay } from 'vuetify'

// Destructure only the keys you want to use
const { xs } = useDisplay()

const books = ref<Book[]>()

/**
 * Gets books from the API
 */
async function getBooks(): Promise<void> {

  try {
    const booksResponse = await axios.get<Book[]>(`https://localhost:7204/books`)
    // Set the books
    if (booksResponse) {
      books.value = booksResponse.data//.map(b => {return <Book> { title: b.title }});

      console.log(books.value)
    }
  }
  catch (ex) {

  }

}

// Get books from API
getBooks()

</script>
