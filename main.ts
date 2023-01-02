
import { Application, Router, helpers } from "./deps.ts";
import { generateWisdom } from "./wisdom.ts";

const app = new Application();
const router = new Router();

const ANALYTICS = `https://${Deno.env.get("ANALYTICS_BASE")}/${Deno.env.get("ANALYTICS_CAMPAIGN_ID")}`;

router
  .get("/", async (ctx: any) => {
    const referrer = helpers.getQuery(ctx)["re"];
    if (referrer) {
      fetch(`${ANALYTICS}/visit/${referrer}`, { method: "POST" });
    } else {
      fetch(`${ANALYTICS}`, { method: "POST" });
    }
    const page = await Deno.readTextFile("./duck/index.html");
    ctx.response.body = page.replace("%WISDOM%", generateWisdom());
    ctx.response.headers.set("Content-Type", "text/html");
  })
  .get("/wisdom", async (ctx: any) => {
    const referrer = helpers.getQuery(ctx)["re"];
    if (referrer) {
      fetch(`${ANALYTICS}/visit/${referrer}`, { method: "POST" });
    } else {
      fetch(`${ANALYTICS}`, { method: "POST" });
    }
    const page = await Deno.readTextFile("./duck/wisdom.html");
    ctx.response.body = page.replace("%WISDOM%", generateWisdom());
    ctx.response.headers.set("Content-Type", "text/html");
  })
  .get("/privacy", async (ctx: any) => {
    ctx.response.body = await Deno.readTextFile("./duck/privacy.html");
    ctx.response.headers.set("Content-Type", "text/html");
  });

router
  .get("/api/wisdom/dispense", (ctx: any) => {
    const referrer = helpers.getQuery(ctx)["re"];
    if (referrer) {
      fetch(`${ANALYTICS}/interaction/${referrer}`, { method: "POST" });
    } else {
      fetch(`${ANALYTICS}/interaction`, { method: "POST" });
    }
    ctx.response.body = generateWisdom();
  })
  .get("/api/wisdom/json", (ctx: any) => {
    const referrer = helpers.getQuery(ctx)["re"];
    if (referrer) {
      fetch(`${ANALYTICS}/interaction/${referrer}`, { method: "POST" });
    } else {
      fetch(`${ANALYTICS}/interaction`, { method: "POST" });
    }
    ctx.response.body = `{"wisdom":"${generateWisdom()}"}`;
    ctx.response.headers.set("Content-Type", "application/json");
  });

app.use(router.routes());
app.use(router.allowedMethods());

// Send static content
app.use(async (context) => {
  await context.send({ root: `${Deno.cwd()}/duck/assets` });
});

console.log("http://localhost:8000");
await app.listen({ port: 8000 });