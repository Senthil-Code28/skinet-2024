import{a,b as p,n as o}from"./chunk-FA3U46QG.js";import{ea as i,ka as n}from"./chunk-55L6EDGV.js";var s=class e{baseUrl=o.apiUrl;http=n(p);getOrders(r){let t=new a;return r.filter&&r.filter!=="All"&&(t=t.append("status",r.filter)),t=t.append("pageIndex",r.pageNumber),t=t.append("pageSize",r.pageSize),this.http.get(this.baseUrl+"admin/orders",{params:t})}getOrder(r){return this.http.get(this.baseUrl+"admin/orders/"+r)}refundOrder(r){return this.http.post(this.baseUrl+"admin/orders/refund/"+r,{})}static \u0275fac=function(t){return new(t||e)};static \u0275prov=i({token:e,factory:e.\u0275fac,providedIn:"root"})};export{s as a};
