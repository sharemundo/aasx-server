/*
 * DotAAS Part 2 | HTTP/REST | Registry and Discovery
 *
 * The registry and discovery interface as part of Details of the Asset Administration Shell Part 2
 *
 * OpenAPI spec version: Final-Draft
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AdminShellNS;
using IdentityModel.Client;
using IO.Swagger.Registry.Attributes;
using IO.Swagger.Registry.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IO.Swagger.Registry.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class RegistryAndDiscoveryInterfaceApiController : ControllerBase
    {
        /// <summary>
        /// Deletes all Asset identifier key-value-pair linked to an Asset Administration Shell to edit discoverable content
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Asset identifier key-value-pairs deleted successfully</response>
        [HttpDelete]
        [Route("/lookup/shells/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteAllAssetLinksById")]
        public virtual IActionResult DeleteAllAssetLinksById([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an Asset Administration Shell Descriptor, i.e. de-registers an AAS
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Asset Administration Shell Descriptor deleted successfully</response>
        [HttpDelete]
        [Route("/registry/shell-descriptors/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteAssetAdministrationShellDescriptorById")]
        public virtual IActionResult DeleteAssetAdministrationShellDescriptorById([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a Submodel Descriptor, i.e. de-registers a submodel
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Submodel Descriptor deleted successfully</response>
        [HttpDelete]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteSubmodelDescriptorById")]
        public virtual IActionResult DeleteSubmodelDescriptorById([FromRoute][Required] string aasIdentifier, [FromRoute][Required] string submodelIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all Asset Administration Shell Descriptors
        /// </summary>
        /// <response code="200">Requested Asset Administration Shell Descriptors</response>
        /// <param name="assetId">An Asset identifier (BASE64-URL-encoded identifier)</param>
        [HttpGet]
        [Route("/registry/shell-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("GetAllAssetAdministrationShellDescriptors")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<AssetAdministrationShellDescriptor>), description: "Requested Asset Administration Shell Descriptors")]
        public virtual IActionResult GetAllAssetAdministrationShellDescriptors(
            [FromQuery] String assetId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<AssetAdministrationShellDescriptor>));
            /*
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<AssetAdministrationShellDescriptor>>(exampleJson)
            : default(List<AssetAdministrationShellDescriptor>);            //TODO: Change the data returned
            return new ObjectResult(example);
            */
            try
            {
                var assetList = new List<String>();
                if (assetId != null && assetId != "")
                {
                    assetList.Add(assetId);
                }

                var aasList = getFromAasRegistry(null, assetList);

                return new ObjectResult(aasList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns a list of Asset Administration Shell ids based on Asset identifier key-value-pairs
        /// </summary>
        /// <param name="assetIds">The key-value-pair of an Asset identifier (BASE64-URL-encoded JSON-serialized key-value-pairs)</param>
        /// <param name="assetId">An Asset identifier (BASE64-URL-encoded identifier)</param>
        /// <response code="200">Requested Asset Administration Shell ids</response>
        [HttpGet]
        [Route("/lookup/shells")]
        [ValidateModelState]
        [SwaggerOperation("GetAllAssetAdministrationShellIdsByAssetLink")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<string>), description: "Requested Asset Administration Shell ids")]
        public virtual IActionResult GetAllAssetAdministrationShellIdsByAssetLink(
            [FromQuery] List<IdentifierKeyValuePair> assetIds,
            [FromQuery] String assetId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<string>));
            /*
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<string>>(exampleJson)
                        : default(List<string>);            //TODO: Change the data returned
            return new ObjectResult(example);

            [
            {"key": "globalAssetId", "subjectId": "x", "value": "http://example.company/myAsset"},
            {"key": "myOwnInternalAssetId", "subjectId": "x", "value": "12345ABC"}
            ]
            */

            try
            {
                //collect aasetIds from list
                var assetList = new List<String>();
                foreach (var kv in assetIds)
                {
                    if (kv.Value != "")
                        assetList.Add(kv.Value);
                }
                // single assetId
                if (assetId != null && assetId != "")
                {
                    assetList.Add(assetId);
                }

                var aasList = new List<String>();

                var aasDecsriptorList = getFromAasRegistry(null, assetList);

                foreach (var ad in aasDecsriptorList)
                {
                    aasList.Add(ad.Identification);
                }

                return new ObjectResult(aasList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns a list of Asset identifier key-value-pairs based on an Asset Administration Shell id to edit discoverable content
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested Asset identifier key-value-pairs</response>
        [HttpGet]
        [Route("/lookup/shells/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("GetAllAssetLinksById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<IdentifierKeyValuePair>), description: "Requested Asset identifier key-value-pairs")]
        public virtual IActionResult GetAllAssetLinksById([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<IdentifierKeyValuePair>));
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<IdentifierKeyValuePair>>(exampleJson)
            : default(List<IdentifierKeyValuePair>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Returns all Submodel Descriptors
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested Submodel Descriptors</response>
        [HttpGet]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("GetAllSubmodelDescriptors")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SubmodelDescriptor>), description: "Requested Submodel Descriptors")]
        public virtual IActionResult GetAllSubmodelDescriptors([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<SubmodelDescriptor>));
            string exampleJson = null;
            exampleJson = "[ {\n  \"semanticId\" : \"\",\n  \"identification\" : \"identification\",\n  \"idShort\" : \"idShort\",\n  \"administration\" : {\n    \"version\" : \"version\",\n    \"revision\" : \"revision\"\n  },\n  \"description\" : [ {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  }, {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  } ]\n}, {\n  \"semanticId\" : \"\",\n  \"identification\" : \"identification\",\n  \"idShort\" : \"idShort\",\n  \"administration\" : {\n    \"version\" : \"version\",\n    \"revision\" : \"revision\"\n  },\n  \"description\" : [ {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  }, {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  } ]\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<SubmodelDescriptor>>(exampleJson)
            : default(List<SubmodelDescriptor>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        List<AssetAdministrationShellDescriptor> getFromAasRegistry(
            string getAasIdBase64 = null,
            List<string> getAssetListBase64 = null)
        {
            List<AssetAdministrationShellDescriptor> result = new List<AssetAdministrationShellDescriptor>();

            if (getAasIdBase64 != null && getAssetListBase64 != null)
                return result;

            if (aasRegistry != null)
            {
                AssetAdministrationShellDescriptor ad = null;
                foreach (var sme in aasRegistry.submodelElements)
                {
                    if (sme.submodelElement is AdminShell.SubmodelElementCollection smc)
                    {
                        string aasID = "";
                        string assetID = "";
                        string descriptorJSON = "";
                        foreach (var sme2 in smc.value)
                        {
                            if (sme2.submodelElement is AdminShell.Property p)
                            {
                                switch (p.idShort)
                                {
                                    case "aasID":
                                        aasID = p.value;
                                        break;
                                    case "assetID":
                                        assetID = p.value;
                                        break;
                                    case "descriptorJSON":
                                        descriptorJSON = p.value;
                                        break;
                                }

                            }
                        }
                        bool found = false;
                        if (getAasIdBase64 == null && (getAssetListBase64 == null || getAssetListBase64.Count == 0))
                            found = true;
                        if (getAasIdBase64 != null)
                        {
                            if (aasID != "" && descriptorJSON != "")
                            {
                                if (getAasIdBase64 == Base64UrlEncoder.Encode(aasID))
                                {
                                    found = true;
                                }
                            }
                        }
                        if (getAssetListBase64 != null && getAssetListBase64.Count != 0)
                        {
                            if (assetID != "" && descriptorJSON != "")
                            {
                                if (getAssetListBase64.Contains(Base64UrlEncoder.Encode(assetID)))
                                {
                                    found = true;
                                }
                            }
                        }
                        if (found)
                        {
                            ad = JsonConvert.DeserializeObject<AssetAdministrationShellDescriptor>(descriptorJSON);
                            result.Add(ad);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a specific Asset Administration Shell Descriptor
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested Asset Administration Shell Descriptor</response>
        [HttpGet]
        [Route("/registry/shell-descriptors/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("GetAssetAdministrationShellDescriptorById")]
        [SwaggerResponse(statusCode: 200, type: typeof(AssetAdministrationShellDescriptor), description: "Requested Asset Administration Shell Descriptor")]
        public virtual IActionResult GetAssetAdministrationShellDescriptorById([FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(AssetAdministrationShellDescriptor));
            /*
            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<AssetAdministrationShellDescriptor>(exampleJson)
            : default(AssetAdministrationShellDescriptor);            //TODO: Change the data returned
            return new ObjectResult(example);
            */
            var timestamp = DateTime.UtcNow;
            // InitRegistry(timestamp);

            try
            {
                var aasList = getFromAasRegistry(aasIdentifier, null);

                return new ObjectResult(aasList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns a specific Submodel Descriptor
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (BASE64-URL-encoded)</param>
        /// <response code="200">Requested Submodel Descriptor</response>
        [HttpGet]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("GetSubmodelDescriptorById")]
        [SwaggerResponse(statusCode: 200, type: typeof(SubmodelDescriptor), description: "Requested Submodel Descriptor")]
        public virtual IActionResult GetSubmodelDescriptorById([FromRoute][Required] string aasIdentifier, [FromRoute][Required] string submodelIdentifier)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(SubmodelDescriptor));
            string exampleJson = null;
            exampleJson = "{\n  \"semanticId\" : \"\",\n  \"identification\" : \"identification\",\n  \"idShort\" : \"idShort\",\n  \"administration\" : {\n    \"version\" : \"version\",\n    \"revision\" : \"revision\"\n  },\n  \"description\" : [ {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  }, {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  } ]\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<SubmodelDescriptor>(exampleJson)
            : default(SubmodelDescriptor);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Creates all Asset identifier key-value-pair linked to an Asset Administration Shell to edit discoverable content
        /// </summary>
        /// <param name="body">Asset identifier key-value-pairs</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="201">Asset identifier key-value-pairs created successfully</response>
        [HttpPost]
        [Route("/lookup/shells/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("PostAllAssetLinksById")]
        [SwaggerResponse(statusCode: 201, type: typeof(List<IdentifierKeyValuePair>), description: "Asset identifier key-value-pairs created successfully")]
        public virtual IActionResult PostAllAssetLinksById([FromBody] List<IdentifierKeyValuePair> body, [FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(List<IdentifierKeyValuePair>));
            string exampleJson = null;
            exampleJson = "[ \"\", \"\" ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<IdentifierKeyValuePair>>(exampleJson)
            : default(List<IdentifierKeyValuePair>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        static void addAasToRegistry(AdminShellNS.AdminShellPackageEnv env, DateTime timestamp)
        {
            var aas = env.AasEnv.AdministrationShells[0];

            AssetAdministrationShellDescriptor ad = new AssetAdministrationShellDescriptor();
            string asset = aas.assetRef?[0].value;

            // ad.Administration.Version = aas.administration.version;
            // ad.Administration.Revision = aas.administration.revision;
            ad.IdShort = aas.idShort;
            ad.Identification = aas.identification.id;
            var e = new Endpoint();
            e.ProtocolInformation = new ProtocolInformation();
            e.ProtocolInformation.EndpointAddress =
                AasxServer.Program.externalBlazor + "/shells/" +
                Base64UrlEncoder.Encode(ad.Identification) +
                "/aas";
            e.Interface = "AAS-1.0";
            ad.Endpoints = new List<Endpoint>();
            ad.Endpoints.Add(e);
            var gr = new GlobalReference();
            gr.Value = new List<string>();
            gr.Value.Add(asset);
            ad.GlobalAssetId = gr;
            // Submodels
            if (aas.submodelRefs != null && aas.submodelRefs.Count > 0)
            {
                ad.SubmodelDescriptors = new List<SubmodelDescriptor>();
                foreach (var smr in aas.submodelRefs)
                {
                    var sm = env.AasEnv.FindSubmodel(smr);
                    if (sm != null && sm.idShort != null)
                    {
                        SubmodelDescriptor sd = new SubmodelDescriptor();
                        sd.IdShort = sm.idShort;
                        sd.Identification = sm.identification.id;
                        var esm = new Endpoint();
                        esm.ProtocolInformation = new ProtocolInformation();
                        esm.ProtocolInformation.EndpointAddress =
                            AasxServer.Program.externalBlazor + "/shells/" +
                            Base64UrlEncoder.Encode(ad.Identification) + "/aas/submodels/" +
                            Base64UrlEncoder.Encode(sd.Identification) +
                            "/submodel/submodel-elements";
                        esm.Interface = "SUBMODEL-1.0";
                        sd.Endpoints = new List<Endpoint>();
                        sd.Endpoints.Add(esm);
                        if (sm.semanticId != null)
                        {
                            var sid = sm.semanticId.GetAsExactlyOneKey();
                            if (sid != null)
                            {
                                gr = new GlobalReference();
                                gr.Value = new List<string>();
                                gr.Value.Add(sid.value);
                                sd.SemanticId = gr;
                            }
                        }
                        ad.SubmodelDescriptors.Add(sd);
                    }
                }
            }
            // add to internal registry
            addAasDescriptorToRegistry(ad, timestamp, true);

            // POST Descriptor to Registry
            foreach (var pr in postRegistry)
            {
                string accessToken = null;
                string requestPath = pr + "/registry/shell-descriptors";
                string json = JsonConvert.SerializeObject(ad);

                var handler = new HttpClientHandler();

                if (AasxServer.AasxTask.proxy != null)
                    handler.Proxy = AasxServer.AasxTask.proxy;
                else
                    handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;

                var client = new HttpClient(handler);
                if (accessToken != null)
                    client.SetBearerToken(accessToken);

                if (json != "")
                {
                    bool error = false;
                    HttpResponseMessage response = new HttpResponseMessage();
                    try
                    {
                        Console.WriteLine("POST " + requestPath);
                        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                        var task = Task.Run(async () =>
                        {
                            response = await client.PostAsync(
                                requestPath, content);
                        });
                        task.Wait();
                        error = !response.IsSuccessStatusCode;
                    }
                    catch
                    {
                        error = true;
                    }
                    if (error)
                    {
                        string r = "ERROR POST; " + response.StatusCode.ToString();
                        r += " ; " + requestPath;
                        if (response.Content != null)
                            r += " ; " + response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(r);
                    }
                }
            }
        }

        static void addAasDescriptorToRegistry(AssetAdministrationShellDescriptor ad, DateTime timestamp, bool initial = false)
        {
            string aasID = ad.Identification;
            string assetID = "";
            if (ad.GlobalAssetId is GlobalReference gr)
            {
                assetID = gr.Value[0];
            }
            // overwrite existing entry, if assetID AND aasID are identical
            if (!initial)
            {
                foreach (var e in aasRegistry?.submodelElements)
                {
                    if (e.submodelElement is AdminShell.SubmodelElementCollection ec)
                    {
                        int found = 0;
                        AdminShell.Property pjson = null;
                        foreach (var e2 in ec.value)
                        {
                            if (e2.submodelElement is AdminShell.Property ep)
                            {
                                if (ep.idShort == "aasID" && ep.value == aasID)
                                    found++;
                                if (ep.idShort == "assetID" && ep.value == assetID)
                                    found++;
                                if (ep.idShort == "descriptorJSON")
                                    pjson = ep;
                            }
                        }
                        if (found == 2 && pjson != null)
                        {
                            string s = JsonConvert.SerializeObject(ad);
                            if (s != pjson.value)
                            {
                                pjson.TimeStampCreate = timestamp;
                                pjson.TimeStamp = timestamp;
                                pjson.value = s;
                            }
                            return;
                        }
                    }
                }
            }

            // add new entry
            AdminShell.SubmodelElementCollection c = AdminShell.SubmodelElementCollection.CreateNew("ShellDescriptor_" + aasRegistryCount++);
            c.TimeStampCreate = timestamp;
            c.TimeStamp = timestamp;
            var p = AdminShell.Property.CreateNew("aasID");
            p.TimeStampCreate = timestamp;
            p.TimeStamp = timestamp;
            p.value = aasID;
            c.value.Add(p);
            p = AdminShell.Property.CreateNew("assetID");
            p.TimeStampCreate = timestamp;
            p.TimeStamp = timestamp;
            if (assetID != "")
            {
                p.value = assetID;
            }
            c.value.Add(p);
            p = AdminShell.Property.CreateNew("descriptorJSON");
            p.TimeStampCreate = timestamp;
            p.TimeStamp = timestamp;
            p.value = JsonConvert.SerializeObject(ad);
            c.value.Add(p);
            aasRegistry?.submodelElements.Add(c);
        }

        static AdminShell.Submodel aasRegistry = null;
        static AdminShell.Submodel submodelRegistry = null;
        static int aasRegistryCount = 0;
        static int submodelRegistryCount = 0;
        static List<string> postRegistry = new List<string>();

        static bool init = false;
        public static void initRegistry(DateTime timestamp)
        {
            if (init)
                return;
            init = true;

            if (aasRegistry == null || submodelRegistry == null)
            {
                foreach (AdminShellNS.AdminShellPackageEnv env in AasxServer.Program.env)
                {
                    if (env != null)
                    {
                        var aas = env.AasEnv.AdministrationShells[0];
                        if (aas.idShort == "REGISTRY")
                        {
                            if (aas.submodelRefs != null && aas.submodelRefs.Count > 0)
                            {
                                foreach (var smr in aas.submodelRefs)
                                {
                                    var sm = env.AasEnv.FindSubmodel(smr);
                                    if (sm != null && sm.idShort != null)
                                    {
                                        if (sm.idShort == "AASREGISTRY")
                                            aasRegistry = sm;
                                        if (sm.idShort == "SUBMODELREGISTRY")
                                            submodelRegistry = sm;
                                    }
                                }
                            }
                        }
                    }
                }
                if (aasRegistry != null)
                {
                    foreach (var sme in aasRegistry.submodelElements)
                    {
                        if (sme.submodelElement is AdminShell.Property p)
                        {
                            if (p.idShort.ToLower() == "postregistry")
                            {
                                Console.WriteLine("POST to Registry: " + p.value);
                                postRegistry.Add(p.value);
                            }
                        }
                    }
                    foreach (AdminShellNS.AdminShellPackageEnv env in AasxServer.Program.env)
                    {
                        if (env != null)
                        {
                            if (env != null)
                            {
                                var aas = env.AasEnv.AdministrationShells[0];
                                if (aas.idShort != "REGISTRY")
                                {
                                    addAasToRegistry(env, timestamp);
                                }
                            }
                        }
                    }
                }
            }
            AasxServer.Program.signalNewData(2);
        }

        /// <summary>
        /// Creates a new Asset Administration Shell Descriptor, i.e. registers an AAS
        /// </summary>
        /// <param name="body">Asset Administration Shell Descriptor object</param>
        /// <response code="201">Asset Administration Shell Descriptor created successfully</response>
        [HttpPost]
        [Route("/registry/shell-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("PostAssetAdministrationShellDescriptor")]
        [SwaggerResponse(statusCode: 201, type: typeof(AssetAdministrationShellDescriptor), description: "Asset Administration Shell Descriptor created successfully")]
        public virtual IActionResult PostAssetAdministrationShellDescriptor([FromBody] AssetAdministrationShellDescriptor body)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(AssetAdministrationShellDescriptor));
            /*
            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<AssetAdministrationShellDescriptor>(exampleJson)
            : default(AssetAdministrationShellDescriptor);            //TODO: Change the data returned
            */
            var timestamp = DateTime.UtcNow;
            // InitRegistry(timestamp);

            Console.WriteLine("POST /registry/shell-descriptors");
            addAasDescriptorToRegistry(body, timestamp);

            AasxServer.Program.signalNewData(2);

            // return new ObjectResult(example);
            return new ObjectResult("ok");
        }

        /// <summary>
        /// Creates a new Submodel Descriptor, i.e. registers a submodel
        /// </summary>
        /// <param name="body">Submodel Descriptor object</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="201">Submodel Descriptor created successfully</response>
        [HttpPost]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors")]
        [ValidateModelState]
        [SwaggerOperation("PostSubmodelDescriptor")]
        [SwaggerResponse(statusCode: 201, type: typeof(SubmodelDescriptor), description: "Submodel Descriptor created successfully")]
        public virtual IActionResult PostSubmodelDescriptor([FromBody] SubmodelDescriptor body, [FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(SubmodelDescriptor));
            string exampleJson = null;
            exampleJson = "{\n  \"semanticId\" : \"\",\n  \"identification\" : \"identification\",\n  \"idShort\" : \"idShort\",\n  \"administration\" : {\n    \"version\" : \"version\",\n    \"revision\" : \"revision\"\n  },\n  \"description\" : [ {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  }, {\n    \"language\" : \"language\",\n    \"text\" : \"text\"\n  } ]\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<SubmodelDescriptor>(exampleJson)
            : default(SubmodelDescriptor);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Updates an existing Asset Administration Shell Descriptor
        /// </summary>
        /// <param name="body">Asset Administration Shell Descriptor object</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Asset Administration Shell Descriptor updated successfully</response>
        [HttpPut]
        [Route("/registry/shell-descriptors/{aasIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("PutAssetAdministrationShellDescriptorById")]
        public virtual IActionResult PutAssetAdministrationShellDescriptorById([FromBody] AssetAdministrationShellDescriptor body, [FromRoute][Required] string aasIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing Submodel Descriptor
        /// </summary>
        /// <param name="body">Submodel Descriptor object</param>
        /// <param name="aasIdentifier">The Asset Administration Shell’s unique id (BASE64-URL-encoded)</param>
        /// <param name="submodelIdentifier">The Submodel’s unique id (BASE64-URL-encoded)</param>
        /// <response code="204">Submodel Descriptor updated successfully</response>
        [HttpPut]
        [Route("/registry/shell-descriptors/{aasIdentifier}/submodel-descriptors/{submodelIdentifier}")]
        [ValidateModelState]
        [SwaggerOperation("PutSubmodelDescriptorById")]
        public virtual IActionResult PutSubmodelDescriptorById([FromBody] SubmodelDescriptor body, [FromRoute][Required] string aasIdentifier, [FromRoute][Required] string submodelIdentifier)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }
    }
}
