using Customer360.Data.Entity;
using System.Xml;

namespace Customer360.Data
{
    public class UsageRepository
    {
        private readonly Dictionary<string, string> _serviceResponses = new()
        {
            { "FBB", @"<?xml version=""1.0"" encoding=""utf-8""?><soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""><soapenv:Body><NS1:RetrieveUsageSummaryRs xmlns:NS1=""http://www.te.eg/esb/messages/retrieveusagesummary""><NS1:ResponseHeader><FunctionId>10003008</FunctionId><RequestId>RUS031</RequestId><ReturnCode>0</ReturnCode><ReturnDesc>Success</ReturnDesc></NS1:ResponseHeader><NS1:ResponseBody><NS1:Subscriber><FreeUnitUsages><FreeUnitUsage><FreeUnitName>TotalBroadBandQuota</FreeUnitName><FreeUnitType>TotalBroadBandQuotaType</FreeUnitType><UnitsInitialNumber>143360</UnitsInitialNumber><UnitsUnUsedAmount>93980</UnitsUnUsedAmount><UnitsUsedAmount>49380</UnitsUsedAmount><UsageStartDate>2025-08-22</UsageStartDate><UsageEndDate>2025-09-22</UsageEndDate></FreeUnitUsage><FreeUnitUsage><FreeUnitName>BasicBroadBandQuota</FreeUnitName><FreeUnitType>BasicBroadBandQuotaType</FreeUnitType><UnitsInitialNumber>143360</UnitsInitialNumber><UnitsUnUsedAmount>93980</UnitsUnUsedAmount><UnitsUsedAmount>49380</UnitsUsedAmount></FreeUnitUsage></FreeUnitUsages></NS1:Subscriber></NS1:ResponseBody></NS1:RetrieveUsageSummaryRs></soapenv:Body></soapenv:Envelope>" },
            {"Mobile" ,@"<?xml version=""1.0"" encoding=""utf-8""?><soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""><soapenv:Body><NS1:RetrieveUsageSummaryRs xmlns:NS1=""http://www.te.eg/esb/messages/retrieveusagesummary""><NS1:ResponseHeader><FunctionId>10200002</FunctionId><RequestId>RUS031</RequestId><ReturnCode>0</ReturnCode><ReturnDesc>Success</ReturnDesc></NS1:ResponseHeader><NS1:ResponseBody><NS1:Subscriber><FreeUnitUsages><FreeUnitUsage><FreeUnitName>Corporate Mobile Internet</FreeUnitName><FreeUnitType>C_Corporate_Internet</FreeUnitType><UnitMeasurementId>1106</UnitMeasurementId><UnitMeasurementName>MB</UnitMeasurementName><UnitsInitialNumber>21800</UnitsInitialNumber><UnitsUnUsedAmount>231</UnitsUnUsedAmount><FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000395736555</FreeUnitInstanceId><FreeUnitInitialAmount>200</FreeUnitInitialAmount><FreeUnitCurrentAmount>0</FreeUnitCurrentAmount><EffectiveDate>20250802221306</EffectiveDate><ExpiryDate>20250901210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>8</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000395714595</FreeUnitInstanceId><FreeUnitInitialAmount>200</FreeUnitInitialAmount><FreeUnitCurrentAmount>0</FreeUnitCurrentAmount><EffectiveDate>20250802211716</EffectiveDate><ExpiryDate>20250901210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>8</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000396124473</FreeUnitInstanceId><FreeUnitInitialAmount>20000</FreeUnitInitialAmount><FreeUnitCurrentAmount>0</FreeUnitCurrentAmount><EffectiveDate>20250804210000</EffectiveDate><ExpiryDate>20250904210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>1</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000395791415</FreeUnitInstanceId><FreeUnitInitialAmount>200</FreeUnitInitialAmount><FreeUnitCurrentAmount>0</FreeUnitCurrentAmount><EffectiveDate>20250803055346</EffectiveDate><ExpiryDate>20250901210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>8</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000399023000</FreeUnitInstanceId><FreeUnitInitialAmount>200</FreeUnitInitialAmount><FreeUnitCurrentAmount>7</FreeUnitCurrentAmount><EffectiveDate>20250820102433</EffectiveDate><ExpiryDate>20250918210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>8</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000399022538</FreeUnitInstanceId><FreeUnitInitialAmount>200</FreeUnitInitialAmount><FreeUnitCurrentAmount>0</FreeUnitCurrentAmount><EffectiveDate>20250820094620</EffectiveDate><ExpiryDate>20250918210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>8</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000399022596</FreeUnitInstanceId><FreeUnitInitialAmount>200</FreeUnitInitialAmount><FreeUnitCurrentAmount>11</FreeUnitCurrentAmount><EffectiveDate>20250820075711</EffectiveDate><ExpiryDate>20250918210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>8</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000399021235</FreeUnitInstanceId><FreeUnitInitialAmount>200</FreeUnitInitialAmount><FreeUnitCurrentAmount>14</FreeUnitCurrentAmount><EffectiveDate>20250820082553</EffectiveDate><ExpiryDate>20250918210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>8</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000399017975</FreeUnitInstanceId><FreeUnitInitialAmount>200</FreeUnitInitialAmount><FreeUnitCurrentAmount>3</FreeUnitCurrentAmount><EffectiveDate>20250820073443</EffectiveDate><ExpiryDate>20250918210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>8</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000399048906</FreeUnitInstanceId><FreeUnitInitialAmount>200</FreeUnitInitialAmount><FreeUnitCurrentAmount>194</FreeUnitCurrentAmount><EffectiveDate>20250820111627</EffectiveDate><ExpiryDate>20250918210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>8</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails></FreeUnitDetails></FreeUnitUsage><FreeUnitUsage><FreeUnitName>VPN_Free Call</FreeUnitName><FreeUnitType>C_VPN_Free_Call</FreeUnitType><UnitMeasurementId>1003</UnitMeasurementId><UnitMeasurementName>Minutes</UnitMeasurementName><UnitsInitialNumber>1500</UnitsInitialNumber><UnitsUnUsedAmount>1193</UnitsUnUsedAmount><FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000396124475</FreeUnitInstanceId><FreeUnitInitialAmount>1500</FreeUnitInitialAmount><FreeUnitCurrentAmount>1193</FreeUnitCurrentAmount><EffectiveDate>20250804210000</EffectiveDate><ExpiryDate>20250904210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>1</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails></FreeUnitDetails></FreeUnitUsage><FreeUnitUsage><FreeUnitName>Corporate Unit</FreeUnitName><FreeUnitType>C_CorporateUnit</FreeUnitType><UnitMeasurementId>10000</UnitMeasurementId><UnitMeasurementName>Unit</UnitMeasurementName><UnitsInitialNumber>13000</UnitsInitialNumber><UnitsUnUsedAmount>0</UnitsUnUsedAmount><FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000396124474</FreeUnitInstanceId><FreeUnitInitialAmount>13000</FreeUnitInitialAmount><FreeUnitCurrentAmount>0</FreeUnitCurrentAmount><EffectiveDate>20250804210000</EffectiveDate><ExpiryDate>20250904210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>1</FreeUnitOriginType><OfferingKey><OfferingId>362005</OfferingId><PurchaseSeq>201993089874127</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>Y</RollOverFlag></FreeUnitDetails></FreeUnitDetails></FreeUnitUsage><FreeUnitUsage><FreeUnitName>New Mobile Internet_Corp</FreeUnitName><FreeUnitType>C_New_Mobile_Internet_Corp</FreeUnitType><UnitMeasurementId>1106</UnitMeasurementId><UnitMeasurementName>MB</UnitMeasurementName><UnitsInitialNumber>55020</UnitsInitialNumber><UnitsUnUsedAmount>10879</UnitsUnUsedAmount><FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000396124476</FreeUnitInstanceId><FreeUnitInitialAmount>8020</FreeUnitInitialAmount><FreeUnitCurrentAmount>0</FreeUnitCurrentAmount><EffectiveDate>20250803055837</EffectiveDate><ExpiryDate>20250904210000</ExpiryDate><FreeUnitOrigin><OfferingKey></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag><RollOveredTime>20250804210000</RollOveredTime></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000399051041</FreeUnitInstanceId><FreeUnitInitialAmount>47000</FreeUnitInitialAmount><FreeUnitCurrentAmount>10879</FreeUnitCurrentAmount><EffectiveDate>20250820112340</EffectiveDate><ExpiryDate>20250904210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>1</FreeUnitOriginType><OfferingKey><OfferingId>373038</OfferingId><PurchaseSeq>201993661752914</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>Y</RollOverFlag></FreeUnitDetails></FreeUnitDetails></FreeUnitUsage></FreeUnitUsages></NS1:Subscriber></NS1:ResponseBody></NS1:RetrieveUsageSummaryRs></soapenv:Body></soapenv:Envelope>" },
            { "Voice", @"<?xml version=""1.0"" encoding=""utf-8""?><soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""><soapenv:Body><NS1:RetrieveUsageSummaryRs xmlns:NS1=""http://www.te.eg/esb/messages/retrieveusagesummary""><NS1:ResponseHeader><FunctionId>10200002</FunctionId><RequestId>RUS031</RequestId><ReturnCode>0</ReturnCode><ReturnDesc>Success</ReturnDesc></NS1:ResponseHeader><NS1:ResponseBody><NS1:Subscriber><FreeUnitUsages><FreeUnitUsage><FreeUnitName>Local and National Minutes</FreeUnitName><FreeUnitType>C_FV_Normal_VoiceI</FreeUnitType><UnitMeasurementId>1003</UnitMeasurementId><UnitMeasurementName>Minutes</UnitMeasurementName><UnitsInitialNumber>1500</UnitsInitialNumber><UnitsUnUsedAmount>1500</UnitsUnUsedAmount><FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>708000000382380800</FreeUnitInstanceId><FreeUnitInitialAmount>1500</FreeUnitInitialAmount><FreeUnitCurrentAmount>1500</FreeUnitCurrentAmount><EffectiveDate>20250609061926</EffectiveDate><ExpiryDate>20250906210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>1</FreeUnitOriginType><OfferingKey><OfferingId>460475154</OfferingId><PurchaseSeq>201993280679965</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails></FreeUnitDetails></FreeUnitUsage></FreeUnitUsages></NS1:Subscriber></NS1:ResponseBody></NS1:RetrieveUsageSummaryRs></soapenv:Body></soapenv:Envelope>" },
            { "WeGoldGroup1", @"<?xml version=""1.0"" encoding=""utf-8""?><soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""><soapenv:Body><NS1:RetrieveUsageSummaryRs xmlns:NS1=""http://www.te.eg/esb/messages/retrieveusagesummary""><NS1:ResponseHeader><FunctionId>10200002</FunctionId><RequestId>RUS031</RequestId><ReturnCode>0</ReturnCode><ReturnDesc>Success</ReturnDesc></NS1:ResponseHeader><NS1:ResponseBody><NS1:Subscriber><FreeUnitUsages><FreeUnitUsage><FreeUnitName>NEw FMC Units_Internet</FreeUnitName><FreeUnitType>C_NEw_FMC_Units_Internet</FreeUnitType><UnitMeasurementId>10000</UnitMeasurementId><UnitMeasurementName>Unit</UnitMeasurementName><UnitsInitialNumber>9712</UnitsInitialNumber><UnitsUnUsedAmount>9712</UnitsUnUsedAmount><UnitsUsedAmount>0</UnitsUsedAmount><FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>701000000837467052</FreeUnitInstanceId><FreeUnitInitialAmount>4080</FreeUnitInitialAmount><FreeUnitCurrentAmount>4080</FreeUnitCurrentAmount><EffectiveDate>20250731210000</EffectiveDate><ExpiryDate>20250930210000</ExpiryDate><FreeUnitOrigin><OfferingKey></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag><RollOveredTime>20250831210000</RollOveredTime></FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>701000000837467050</FreeUnitInstanceId><FreeUnitInitialAmount>5632</FreeUnitInitialAmount><FreeUnitCurrentAmount>5632</FreeUnitCurrentAmount><EffectiveDate>20250831210000</EffectiveDate><ExpiryDate>20250930210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>1</FreeUnitOriginType><OfferingKey><OfferingId>460480697</OfferingId><PurchaseSeq>201993237886162</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>Y</RollOverFlag></FreeUnitDetails></FreeUnitDetails></FreeUnitUsage><FreeUnitUsage><FreeUnitName>NEw FMC Units</FreeUnitName><FreeUnitType>C_NEw_FMC_Units</FreeUnitType><UnitMeasurementId>10000</UnitMeasurementId><UnitMeasurementName>Unit</UnitMeasurementName><UnitsInitialNumber>1200</UnitsInitialNumber><UnitsUnUsedAmount>1183</UnitsUnUsedAmount><UnitsUsedAmount>17</UnitsUsedAmount><FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>701000000837467049</FreeUnitInstanceId><FreeUnitInitialAmount>1200</FreeUnitInitialAmount><FreeUnitCurrentAmount>1183</FreeUnitCurrentAmount><EffectiveDate>20250831210000</EffectiveDate><ExpiryDate>20250930210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>1</FreeUnitOriginType><OfferingKey><OfferingId>460480697</OfferingId><PurchaseSeq>201993237886162</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails></FreeUnitDetails></FreeUnitUsage><FreeUnitUsage><FreeUnitName>TED Primary Fixed Data</FreeUnitName><FreeUnitType>C_TED_Primary_Fixed_Data</FreeUnitType><UnitMeasurementId>1106</UnitMeasurementId><UnitMeasurementName>MB</UnitMeasurementName><UnitsInitialNumber>204800</UnitsInitialNumber><UnitsUnUsedAmount>198996</UnitsUnUsedAmount><UnitsUsedAmount>5804</UnitsUsedAmount><FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>701000000837467048</FreeUnitInstanceId><FreeUnitInitialAmount>204800</FreeUnitInitialAmount><FreeUnitCurrentAmount>198996</FreeUnitCurrentAmount><EffectiveDate>20250831210000</EffectiveDate><ExpiryDate>20250930210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>1</FreeUnitOriginType><OfferingKey><OfferingId>460480697</OfferingId><PurchaseSeq>201993237886162</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails></FreeUnitDetails></FreeUnitUsage><FreeUnitUsage><FreeUnitName>Shared Intra Voice Revamp</FreeUnitName><FreeUnitType>C_Shared_Intra_Voice_Revamp</FreeUnitType><UnitMeasurementId>1003</UnitMeasurementId><UnitMeasurementName>Minutes</UnitMeasurementName><UnitsInitialNumber>10000</UnitsInitialNumber><UnitsUnUsedAmount>10000</UnitsUnUsedAmount><UnitsUsedAmount>0</UnitsUsedAmount><FreeUnitDetails><FreeUnitDetails><FreeUnitInstanceId>701000000837467051</FreeUnitInstanceId><FreeUnitInitialAmount>10000</FreeUnitInitialAmount><FreeUnitCurrentAmount>10000</FreeUnitCurrentAmount><EffectiveDate>20250831210000</EffectiveDate><ExpiryDate>20250930210000</ExpiryDate><FreeUnitOrigin><FreeUnitOriginType>1</FreeUnitOriginType><OfferingKey><OfferingId>460480697</OfferingId><PurchaseSeq>201993237886162</PurchaseSeq></OfferingKey></FreeUnitOrigin><RollOverFlag>N</RollOverFlag></FreeUnitDetails></FreeUnitDetails></FreeUnitUsage></FreeUnitUsages></NS1:Subscriber></NS1:ResponseBody></NS1:RetrieveUsageSummaryRs></soapenv:Body></soapenv:Envelope>" },
        };


        public List<FreeUnitUsage> GetUsageData(string serviceType, string serviceNumber, bool isGroup = false, string groupId = "")
        {
            string xmlResponse;
            if (isGroup)
            {
                xmlResponse = serviceType switch
                {
                    "FBB" => _serviceResponses[groupId],
                    "Mobile" => _serviceResponses[groupId],
                    _ => throw new ArgumentException("Unsupported group service type")
                };
            }
            else
            {
                xmlResponse = _serviceResponses.ContainsKey(serviceType) ? _serviceResponses[serviceType] : throw new ArgumentException("Unsupported service type");
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlResponse);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("NS1", "http://www.te.eg/esb/messages/retrieveusagesummary");

            XmlNode subscriberNode = xmlDoc.SelectSingleNode("//NS1:Subscriber", nsmgr)
                ?? throw new InvalidOperationException("Subscriber node not found in XML");

            XmlNode freeUnitUsagesNode = subscriberNode.SelectSingleNode("FreeUnitUsages", nsmgr)
                ?? throw new InvalidOperationException("FreeUnitUsages node not found in XML");

            var usages = new List<FreeUnitUsage>();
            foreach (XmlNode usageNode in freeUnitUsagesNode.SelectNodes("FreeUnitUsage", nsmgr)!)
            {
                var usage = new FreeUnitUsage
                {
                    Name = GetNodeValue(usageNode, "FreeUnitName", nsmgr),
                    Type = GetNodeValue(usageNode, "FreeUnitType", nsmgr),
                    InitialNumber = ParseInt(GetNodeValue(usageNode, "UnitsInitialNumber", nsmgr)),
                    UnusedAmount = ParseInt(GetNodeValue(usageNode, "UnitsUnUsedAmount", nsmgr)),
                    UsedAmount = ParseInt(GetNodeValue(usageNode, "UnitsUsedAmount", nsmgr)),
                    MeasurementName = GetNodeValue(usageNode, "UnitMeasurementName", nsmgr),
                    UsageStartDate = GetNodeValue(usageNode, "UsageStartDate", nsmgr),
                    UsageEndDate = GetNodeValue(usageNode, "UsageEndDate", nsmgr)

                };

                XmlNode detailsNode = usageNode.SelectSingleNode("FreeUnitDetails", nsmgr);
                if (detailsNode != null)
                {
                    foreach (XmlNode detailNode in detailsNode.SelectNodes("FreeUnitDetails", nsmgr)!)
                    {
                        var detail = new FreeUnitDetail
                        {
                            InstanceId = GetNodeValue(detailNode, "FreeUnitInstanceId", nsmgr),
                            InitialAmount = ParseInt(GetNodeValue(detailNode, "FreeUnitInitialAmount", nsmgr)),
                            CurrentAmount = ParseInt(GetNodeValue(detailNode, "FreeUnitCurrentAmount", nsmgr)),
                            EffectiveDate = FormatDate(GetNodeValue(detailNode, "EffectiveDate", nsmgr)),
                            ExpiryDate = FormatDate(GetNodeValue(detailNode, "ExpiryDate", nsmgr)),
                            OriginType = GetNodeValue(detailNode.SelectSingleNode("FreeUnitOrigin/FreeUnitOriginType", nsmgr), null, nsmgr) ?? "",
                            OfferingId = GetNodeValue(detailNode.SelectSingleNode("FreeUnitOrigin/OfferingKey/OfferingId", nsmgr), null, nsmgr) ?? "",
                            PurchaseSeq = GetNodeValue(detailNode.SelectSingleNode("FreeUnitOrigin/OfferingKey/PurchaseSeq", nsmgr), null, nsmgr) ?? "",
                            RollOverFlag = GetNodeValue(detailNode, "RollOverFlag", nsmgr),
                            RolloveredTime = GetNodeValue(detailNode, "RollOveredTime", nsmgr)
                        };
                        usage.Details.Add(detail);
                    }
                }
                usages.Add(usage);
            }

            return usages;
        }

        private int ParseInt(string value)
        {
            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int result))
            {
                return 0;
            }
            return result;
        }

        private string GetNodeValue(XmlNode? node, string? xpath, XmlNamespaceManager nsmgr)
        {
            if (string.IsNullOrEmpty(xpath)) return node?.InnerText ?? "";
            var child = node?.SelectSingleNode(xpath, nsmgr);
            return child?.InnerText ?? "";
        }

        private string FormatDate(string fullDate)
        {
            if (string.IsNullOrEmpty(fullDate) || fullDate.Length < 8) return fullDate;
            var year = fullDate.Substring(0, 4);
            var month = fullDate.Substring(4, 2);
            var day = fullDate.Substring(6, 2);
            return $"{int.Parse(month)}-{int.Parse(day)}-{year.Substring(2)}";
        }
    }
}