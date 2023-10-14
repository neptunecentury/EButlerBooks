/**
 * plugins/index.ts
 *
 * Automatically included in `./src/main.ts`
 */

// Plugins
import vuetify from './vuetify'
import router from '../router'

// Types
import type { App } from 'vue'

// Before we use vuetify, set the default theme based on the user's current theme
//let currentTheme = null;

// // Get the theme from the browser local storage. If not available, we simply
// // check the OS default theme.
// if (localStorage) {
//   // Access local storage to get saved theme
//   let savedTheme = localStorage.getItem("ncs:theme");
//   if (savedTheme) {
//     // Set our default to the saved theme
//     currentTheme = savedTheme;

//   }

// }

// // If we don't have a currently saved theme, then get it from the media query and store it.
// if (!currentTheme) {
//   // If there is no default, set default theme based on OS
//   const darkThemeMq = window.matchMedia('(prefers-color-scheme: dark)');
//   if (darkThemeMq.matches) {
//     // Theme set to dark.
//     currentTheme = "dark";

//   } else {
//     // Theme set to light.
//     currentTheme = "light";

//   }

// }

// If there is no default, set default theme based on OS


// Get the current theme
const darkThemeMq = window.matchMedia('(prefers-color-scheme: dark)')
// If the media query matches, it's ark mode. Otherwise, it's light mode.
const colorTheme = darkThemeMq.matches ? "dark" : "light"
// Set theme.
vuetify.theme.global.name.value = colorTheme;

// Now, listen for future changes.
darkThemeMq.addEventListener('change', event => {
  const newColorTheme = event.matches ? "dark" : "light";
  // Set theme.
  vuetify.theme.global.name.value = newColorTheme;
});






export function registerPlugins(app: App) {
  app
    .use(vuetify)
    .use(router)
}
