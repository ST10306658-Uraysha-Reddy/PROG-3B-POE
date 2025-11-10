using municipalService.Models;

namespace municipalService.Storage
{
          
        public class BSTNode
        {
            public ServiceRequest Data;
            public BSTNode Left;
            public BSTNode Right;

            public BSTNode(ServiceRequest data)
            {
                Data = data;
            }
        }

        public class ServiceRequestBST
        {
            private BSTNode root;

            public void Insert(ServiceRequest request)
            {
                root = InsertRecursive(root, request);
            }

            private BSTNode InsertRecursive(BSTNode node, ServiceRequest request)
            {
                if (node == null) return new BSTNode(request);

                int comparison = string.Compare(request.ID, node.Data.ID, StringComparison.OrdinalIgnoreCase);
                if (comparison < 0)
                    node.Left = InsertRecursive(node.Left, request);
                else if (comparison > 0)
                    node.Right = InsertRecursive(node.Right, request);

                return node;
            }

            public ServiceRequest Search(string id)
            {
                return SearchRecursive(root, id);
            }

            private ServiceRequest SearchRecursive(BSTNode node, string id)
            {
                if (node == null) return null;

                int comparison = string.Compare(id, node.Data.ID, StringComparison.OrdinalIgnoreCase);
                if (comparison == 0) return node.Data;
                if (comparison < 0) return SearchRecursive(node.Left, id);
                return SearchRecursive(node.Right, id);
            }

            public List<ServiceRequest> InOrderTraversal()
            {
                var result = new List<ServiceRequest>();
                TraverseInOrder(root, result);
                return result;
            }

            private void TraverseInOrder(BSTNode node, List<ServiceRequest> result)
            {
                if (node == null) return;
                TraverseInOrder(node.Left, result);
                result.Add(node.Data);
                TraverseInOrder(node.Right, result);
            }
        }
    
}

