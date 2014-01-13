<%@ Application Language="C#" %>
<%@ Import Namespace="Tesis" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Tesis.Code" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    void Session_End(object sender, EventArgs e)
    {
        var list = (List<Activity>)Session["activity"];
        DataDataContext db = new DataDataContext();
        db.Activities.InsertAllOnSubmit(list);
        db.SubmitChanges();
    }

    void Session_Start(object sender, EventArgs e)
    {
        Session["activity"] = new List<Activity>();
    }
    
</script>
