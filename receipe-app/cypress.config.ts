import { defineConfig } from "cypress";

export default defineConfig({
  component: {
    specPattern: "tests/components/**/*.spec.tsx",
    supportFile: "cypress/support/component.ts",
    devServer: {
      framework: "react",
      bundler: "vite",
      viteConfig: { server: { port: 0 } }, // auto pick port
    },
  },
e2e: {
    baseUrl: "http://localhost:3005", // adjust to your app port
    specPattern: "tests/e2e/**/*.cy.ts",
    supportFile: "cypress/support/e2e.ts",
  },
});
